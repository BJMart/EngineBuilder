using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            int cmb = cmbLayout.SelectedIndex;
            int bank = 0;
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
            if (cmbLayout.SelectedIndex == 0)
            {
                for (int i = 0; i < cylinders - 1; i++)
                {
                    sw.WriteLine(".connect_wire(wires.wire" + (i + 1) + ", (" + (i + 1) + ".0 / " + cpb + ".0) * cycle)");
                }
                sw.WriteLine(".connect_wire(wires.wire" + (cylinders) + ", (" + (cylinders) + ".0 / " + cpb + ".0) * cycle);");
            }
            sw.WriteLine("}");
            

            
            sw.Close();
            
        }
    }
}
