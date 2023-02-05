using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EngineBuilder
{
    public partial class EngineBuilder : Form
    {
        private void EngineBuilder_Load(object sender, EventArgs e)
        {
           
           
        }
        public EngineBuilder()
        {
           
            InitializeComponent();
        }

     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtBore_TextChanged(object sender, EventArgs e)
        {

            CalculateCapacity();

        }

        private void txtStroke_TextChanged(object sender, EventArgs e )
        {

           
            CalculateCapacity();
        }

       
        private void txtCylinders_TextChanged(object sender, EventArgs e)
        {
           
            CalculateCapacity();
        }
         void CalculateCapacity()
        {
            lblGenerated.Text = "";
            if (txtBore.Text != "" && txtStroke.Text != "" && txtCylinders.Text != "")
            {
                double bore = Convert.ToDouble(txtBore.Text);

                double stroke = Convert.ToDouble(txtStroke.Text);
                int cylinders = Convert.ToInt32(txtCylinders.Text);
                double capacity = 0.7854 * (bore / 10) * (bore / 10) * (stroke / 10) * cylinders;
                txtCapacity.Text = Convert.ToString(Math.Round(capacity));
                

            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
           
            double bore = Convert.ToDouble(txtBore.Text);
            double stroke = Convert.ToDouble(txtStroke.Text);
            int cylinders = Convert.ToInt32(txtCylinders.Text);
            int rpm = Convert.ToInt32(txtRPM.Text);
            int angle = Convert.ToInt32(txtAngle.Text);
            int cmb = cmbLayout.SelectedIndex;
            int bank = 0;
            
           
                string input = txtOrder.Text;
                string[] stringValues = input.Split(' ');
                int[] order = new int[stringValues.Length];

                for (int i = 0; i < stringValues.Length; i++)
                {
                    order[i] = int.Parse(stringValues[i]);
                }
            
            
            if (cmbLayout.SelectedIndex == 0)
            {
                bank = 1;
            }
            else if (cmbLayout.SelectedIndex == 1)
            {
                bank = 2;
            }
            else if (cmbLayout.SelectedIndex == 2)
            {
                bank = 2;
            }
            else if (cmbLayout.SelectedIndex == 3)
            {
                bank = 3;
            }
            else if (cmbLayout.SelectedIndex == 4)
            {
                bank = 4;
            }
            else if (cmbLayout.SelectedIndex == 5)
            {
                bank = cylinders;
            }
            double cpb = cylinders / bank;

            StreamWriter sw = new StreamWriter("generated_" + txtEngineName.Text + ".mr");
            sw.WriteLine("import \"engine_sim.mr\"");
            sw.WriteLine();
            sw.WriteLine("units units()");
            sw.WriteLine("constants constants()");
            sw.WriteLine("impulse_response_library ir_lib()");
            sw.WriteLine();
            sw.WriteLine("private node wires {");
            for (int i = 0; i < cylinders; i++)
            {
                sw.WriteLine("output wire" + (i + 1) + ": ignition_wire();");

            }
            sw.WriteLine("}");
            sw.WriteLine();
            sw.WriteLine("label cycle(720 * units.deg)");
            sw.WriteLine("public node " + txtEngineName.Text + "_ignition {");
            sw.WriteLine("input wires;");
            sw.WriteLine("input timing_curve;");
            sw.WriteLine("input rev_limit: " + rpm + " * units.rpm;");
            sw.WriteLine("alias output __out:");
            sw.WriteLine("ignition_module(timing_curve: timing_curve, rev_limit: rev_limit)");
            //needs finishing
            int tempo = -1;
            for (int j = 0; j < bank; j++)
            {
              
                
                {
                    for (int i = 0; i < cpb; i++)
                    {
                        tempo++;
                        sw.WriteLine();
                        sw.Write(".connect_wire(wires.wire" + (order[tempo]) + ", (" + (i+1) + ".0 / " + (cpb) + ".0) + (" + j + ".0 / " + cylinders +".0) * cycle)");
                        
                    }
                   
                }
            }
            sw.WriteLine(";");
            //up to here
            sw.WriteLine("}");
            sw.WriteLine();
            sw.WriteLine("public node " + txtEngineName.Text + "_camshaft_builder {");
            sw.WriteLine("input intake_lobe_profile;");
            sw.WriteLine("input exhaust_lobe_profile;");
            sw.WriteLine("input lobe_seperation: 110 * units.deg;");
            sw.WriteLine("input intake_lobe_center: lobe_seperation;");
            sw.WriteLine("input exhaust_lobe_center: lobe_seperation;"); ;
            sw.WriteLine("input advance: 0.0 * units.deg;");
            sw.WriteLine("input base_radius: 0.75 * units.inch;");
            sw.WriteLine();

            for (int i = 0; i < bank; i++)
            {
                sw.WriteLine("output intake_cam_" + i + ": _intake_cam_" + i + ";");
                sw.WriteLine("output exhaust_cam_" + i + ": _exhaust_cam_" + i + ";");
            }
            sw.WriteLine("camshaft_parameters params(");
            sw.WriteLine("advance: advance,");
            sw.WriteLine("base_radius: base_radius");
            sw.WriteLine(")");
            sw.WriteLine();

            for (int i = 0; i < bank; i++)
            {
                sw.WriteLine("camshaft _intake_cam_" + i + "(params, lobe_profile: intake_lobe_profile)");
                sw.WriteLine("camshaft _exhaust_cam_" + i + "(params, lobe_profile: exhaust_lobe_profile)");
            }
            sw.WriteLine();
            sw.WriteLine("label rot((720 / " + (cylinders) + ".0) * units.deg)");
            sw.WriteLine("label rot360(360 * units.deg)");
            sw.WriteLine();
            //Cam timings
            for (int i = 0; i < bank; i++)
            {
                //exhaust
                sw.WriteLine("_exhaust_cam_" + i);
                
                for (int j = -1; j < cpb-1; j++)
                {
                    sw.WriteLine(".add_lobe(((rot360 - exhaust_lobe_center) + " + (j+1) + " * rot) + " + (angle * i) + " * units.deg)");
                }
                //intake
                sw.WriteLine("");
                sw.WriteLine("_intake_cam_" + i);
                
                for (int j = -1; j < cpb - 1; j++)
                {
                    sw.WriteLine(".add_lobe(((rot360 - intake_lobe_center) + " + (j+1) + " * rot) + " + (angle * i) + " * units.deg)");
                }
                sw.WriteLine("");
            }
            sw.WriteLine("}");
            sw.WriteLine();
            sw.WriteLine("public node add_flow_sample {");
            sw.WriteLine("input lift;");
            sw.WriteLine("input flow;");
            sw.WriteLine("input this;");
            sw.WriteLine("alias output __out: this;");
            sw.WriteLine();
            sw.WriteLine("this.add_sample(lift * units.thou, k_28inH2O(flow))");
            sw.WriteLine("}");
            sw.WriteLine();
            sw.WriteLine("public node " + txtEngineName.Text + "_cylinder_head {");
            sw.WriteLine("input intake_camshaft;");
            sw.WriteLine("input exhaust_camshaft;");
            sw.WriteLine("input chamber_volume: " + txtChamberVolume.Text + ".0 * units.cc;");
            sw.WriteLine("input intake_runner_volume: " + txtChamberVolume.Text + ".0 * units.cc;");
            sw.WriteLine("input intake_runner_cross_section_area: " + Math.Round(Convert.ToDouble(txtChamberVolume.Text) / (bore/10)) + ".0 * units.cm2;");
            sw.WriteLine("input exhaust_runner_volume: " + txtChamberVolume.Text + ".0 * units.cc;");
            sw.WriteLine("input exhaust_runner_cross_section_area: " + Math.Round(Convert.ToDouble(txtChamberVolume.Text) / (bore / 10)) + ".0 * units.cm2;");
            sw.WriteLine();
            sw.WriteLine("input flow_attenuation: 1.0;");
            sw.WriteLine("input lift_scale: 0.92;");
            sw.WriteLine("input flip_display: false;");
            sw.WriteLine("alias output __out: head;");
            sw.WriteLine();
            sw.WriteLine("function intake_flow(50 * units.thou)");
            sw.WriteLine("intake_flow");
            for (int i = 0; i < (rpm/500); i++)
            {
                sw.WriteLine(".add_flow_sample(" + (i*50) + " * lift_scale, " + (i*25) + " * flow_attenuation)" );
                
            }
            sw.WriteLine();
            sw.WriteLine("function exhaust_flow(50 * units.thou)");
            sw.WriteLine("exhaust_flow");
            for (int i = 0; i < (rpm / 500); i++)
            {
                sw.WriteLine(".add_flow_sample(" + (i * 50) + " * lift_scale, " + (i * 25) + " * flow_attenuation)");
               
            }
            sw.WriteLine();
            sw.WriteLine("cylinder_head head(");
            sw.WriteLine("chamber_volume: chamber_volume,");
            sw.WriteLine("intake_runner_volume: intake_runner_volume,");
            sw.WriteLine("intake_runner_cross_section_area: intake_runner_cross_section_area,");
            sw.WriteLine("exhaust_runner_volume: exhaust_runner_volume,");
            sw.WriteLine("exhaust_runner_cross_section_area: exhaust_runner_cross_section_area,");
            sw.WriteLine("       intake_port_flow: intake_flow,\r\n        exhaust_port_flow: exhaust_flow,\r\n        intake_camshaft: intake_camshaft,\r\n        exhaust_camshaft: exhaust_camshaft,\r\n        flip_display: flip_display");
            sw.WriteLine(")");
            sw.WriteLine("}");
            sw.WriteLine();
            sw.WriteLine("public node " + txtEngineName.Text + "{");
            sw.WriteLine("alias output __out: engine;");
            sw.WriteLine();
            sw.WriteLine("wires wires()");
            sw.WriteLine();
            sw.WriteLine("engine engine(");
            sw.WriteLine("name: \"" + txtEngineName.Text + "\",");
            sw.WriteLine("starter_torque: " + (Convert.ToDouble(txtCapacity.Text)/10) + " * units.lb_ft,");
            sw.WriteLine("redline: " + rpm + " * units.rpm,");
            sw.WriteLine("simulation_frequency: " + rpm + ",");
            sw.WriteLine("fuel: fuel(");
            sw.WriteLine("max_turbulence_effect: 5.0,");
            sw.WriteLine("burning_efficiency_randomness: 0.2,");
            sw.WriteLine("max_burning_efficiency: " + ((Convert.ToDouble(txtCapacity.Text) / 30000)) + ")");
            sw.WriteLine(")");
            sw.WriteLine();
            sw.WriteLine("label stroke(" + stroke + " * units.mm)");
            sw.WriteLine("label bore(" + bore + " * units.mm)");
            sw.WriteLine("label rod_length(" + txtRod.Text + " * units.mm)");
            sw.WriteLine("label compression_height(1.0 * units.inch)");
            sw.WriteLine();
            sw.WriteLine();
            sw.WriteLine();
            sw.WriteLine("crankshaft c0(");
            sw.WriteLine("throw: " + stroke + " / 2,");
            sw.WriteLine("flywheel_mass: " + ((Convert.ToDouble(txtCapacity.Text) / 200)) + " * units.kg,");
            sw.WriteLine("mass: " + ((Convert.ToDouble(txtCapacity.Text) / 500)) + " * units.kg,");
            sw.WriteLine("friction_torque: 5.0 * units.lb_ft,");
            sw.WriteLine("moment_of_inertia: 0.22986844776863666 * 0.2,");
            sw.WriteLine("position_x: 0 * units.inch,");
            sw.WriteLine("position_y: 0.0,");
            sw.WriteLine("tdc: 90 * units.deg");
            sw.WriteLine(")");
            sw.WriteLine();

            for (int i = 0; i < cpb; i++)
            {
                sw.WriteLine("rod_journal rj" + i + "(angle: (" + i + ".0/ " + cylinders + ".0) *360 * units.deg)");
            }
            sw.WriteLine();
            sw.WriteLine("c0");
            for (int i = 0; i < cpb; i++)
            {
                sw.WriteLine(".add_rod_journal(rj" + i + ")");
            }
            sw.WriteLine("engine.add_crankshaft(c0)");
            sw.WriteLine();
            sw.WriteLine("cylinder_bank_parameters bank_params(");
            sw.WriteLine("bore: bore * units.mm,");
            sw.WriteLine("deck_height: stroke / 2 + rod_length + compression_height");
            sw.WriteLine(")");
            sw.WriteLine();
            sw.WriteLine("piston_parameters piston_params(");
            sw.WriteLine("mass: 50 * units.g,");
            sw.WriteLine("compression_height: compression_height,");
            sw.WriteLine("wrist_pin_position: 0 * units.mm,");
            sw.WriteLine("displacement: " + txtCapacity.Text);
            sw.WriteLine(")");
            sw.WriteLine();
            sw.WriteLine("connecting_rod_parameters cr_params(");
            sw.WriteLine("mass: 25.0 * units.g,");
            sw.WriteLine("moment_of_inertia: 0.001,");
            sw.WriteLine("center_of_mass: 0.0,");
            sw.WriteLine("length: rod_length");
            sw.WriteLine(")");
            sw.WriteLine();

           
            sw.WriteLine("intake intake(");
            sw.WriteLine("plenum_volume: 1.0 * units.L,");
            sw.WriteLine("plenum_cross_section_area: 10.0 * units.cm2,");
            sw.WriteLine("intake_flow_rate: k_carb(1000.0),");
            sw.WriteLine("idle_flow_rate: k_carb(0.0),");
            sw.WriteLine("idle_throttle_plate_position: 0.991");
            sw.WriteLine(")");
            sw.WriteLine();
            sw.WriteLine("exhaust_system_parameters es_params(");
            sw.WriteLine("outlet_flow_rate: k_carb(1000.0),");
            sw.WriteLine("primary_tube_length: 10.0 * units.inch,");
            sw.WriteLine("primary_flow_rate: k_carb(200.0),");
            sw.WriteLine("velocity_decay: 0.75,");
            sw.WriteLine("volume: 50.0 * units.L");
            sw.WriteLine(")");
            sw.WriteLine();
            for (int i = 0; i < bank; i++)
            {
                sw.WriteLine("   exhaust_system exhaust" + i + "(es_params, audio_volume: 1.0, impulse_response: ir_lib.real_engine_" + i + ")");
            }
            sw.WriteLine();
            for (int i = 0; i < bank; i++)
            {
                sw.WriteLine("    cylinder_bank b" + i + "(bank_params, angle: " + (angle*(i-1)) +"  * units.deg)");
            }
            tempo = -1;
            for (int i = 0; i < bank; i++)
            {
                sw.WriteLine("b" + i);
                for (int j = 0; j < cpb; j++)
                {
                    tempo++;
                    sw.WriteLine(".add_cylinder(");
                    sw.WriteLine(" piston: piston(piston_params, blowby: k_28inH2O(0.0)),");
                    sw.WriteLine(" connecting_rod: connecting_rod(cr_params),");
                    sw.WriteLine("rod_journal: rj" + j + "," );
                    sw.WriteLine("intake: intake,");
                    sw.WriteLine("exhaust_system: exhaust" + i + ",");
                    sw.WriteLine("ignition_wire: wires.wire" + (order[tempo]));
                    sw.WriteLine(")");
                }
            }
            sw.WriteLine();
            sw.WriteLine("engine");
            for (int i = 0; i < bank; i++)
            {
                sw.WriteLine(".add_cylinder_bank(b" + i + ")");
            }
            sw.WriteLine();
            sw.WriteLine("harmonic_cam_lobe intake_lobe(");
            sw.WriteLine("  duration_at_50_thou: 225 * units.deg,");
            sw.WriteLine("gamma: 1,");
            sw.WriteLine("lift: 12.78 * units.mm,");
            sw.WriteLine("steps: 100");
            sw.WriteLine(")");
            sw.WriteLine();
            sw.WriteLine("harmonic_cam_lobe exhaust_lobe(");
            sw.WriteLine("  duration_at_50_thou: 230 * units.deg,");
            sw.WriteLine("gamma: 1,");
            sw.WriteLine("lift: 12.78 * units.mm,");
            sw.WriteLine("steps: 100");
            sw.WriteLine(")");

            sw.WriteLine();
            sw.WriteLine(txtEngineName.Text+ "_camshaft_builder camshaft(intake_lobe, exhaust_lobe)");
            sw.WriteLine();
            for (int i = 0; i < bank; i++)
            {
                sw.WriteLine("b" + i +".set_cylinder_head (");
                sw.WriteLine(txtEngineName.Text + "_cylinder_head(");
                sw.WriteLine("chamber_volume: " + (Convert.ToDouble(txtCapacity.Text) / 2000) + " * 25 * units.cc," );
                sw.WriteLine("intake_camshaft: camshaft.intake_cam_" + i + ",");
                sw.WriteLine("exhaust_camshaft: camshaft.exhaust_cam_" + i + "");
                sw.WriteLine(")");
                sw.WriteLine(")");
            }
            sw.WriteLine("function timing_curve(1000 * units.rpm)");
            sw.WriteLine("timing_curve");
            for (int i = 0; i < (rpm/1000); i++)
            {
                sw.WriteLine(".add_sample(" + i + "000 * units.rpm, " + (7*i) + " * units.deg)");
            }
            sw.WriteLine("engine.add_ignition_module(");
            sw.WriteLine(txtEngineName.Text + "_ignition(");
            sw.WriteLine("wires: wires,");
            sw.WriteLine("timing_curve: timing_curve,");
            sw.WriteLine("rev_limit: " + rpm + " * units.rpm");
            sw.WriteLine(")");
            sw.WriteLine(")");
            sw.WriteLine("}");
            sw.WriteLine("label car_mass(1500 * units.kg)\r\n\r\nprivate node generic_racecar {\r\n    alias output __out:\r\n        vehicle(\r\n            mass: car_mass,\r\n            drag_coefficient: 0.5,\r\n            cross_sectional_area: (72 * units.inch) * (32 * units.inch),\r\n            diff_ratio: 3.9,\r\n            tire_radius: 16 * units.inch,\r\n            rolling_resistance: 0.015 * car_mass * 9.81,\r\n            stiffness: 50 * units.lb_ft / units.deg,\r\n            damping: 15.0,\r\n            max_flex: 5 * units.deg,\r\n            limit_flex: true,\r\n            simulate_flex: true\r\n        );\r\n}\r\n\r\nprivate node racecar_transmission {\r\n    alias output __out:\r\n        transmission(\r\n            max_clutch_torque: 700 * units.lb_ft,\r\n            max_clutch_flex: 5 * units.deg,\r\n            limit_clutch_flex: true,\r\n            clutch_stiffness: 50 * units.lb_ft / units.deg,\r\n            clutch_damping: 2.0,\r\n            simulate_flex: true\r\n        )\r\n        .add_gear(3.140)\r\n        .add_gear(2.308)\r\n        .add_gear(1.75)\r\n        .add_gear(1.5)\r\n        .add_gear(1.2);\r\n}\r\n\r\npublic node main {\r\n    set_engine(" + txtEngineName.Text +"())\r\n    set_vehicle(generic_racecar())\r\n    set_transmission(racecar_transmission())\r\n}\r\n\r\nmain()\r\n");

            sw.Close();
            lblGenerated.Text = "Engine Generated";
            

            
        }
    }
}
