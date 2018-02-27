using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;

namespace xml_project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        # region variables

        Process r;
        IOdata p;
        Condition d;
        StartEnd ee;
        line l= new line ();
        ArrayList obj = new ArrayList();
        int m;
        int mm;
        int edit_x;
        int edit_y;
        int edit_index = 0;//to determine in button "ok"
        bool saveButton = true;
        # endregion

        # region functions


        //get ellipse information from arraylist
        private StartEnd Arraylistellipse(int i)
        {
            return (StartEnd)obj[i];
        }

        //get rectangle information from arraylist
        private Process Arraylistrectangle(int i)
        {
            return (Process)obj[i];
        }

        //get polygon information from arraylist
        private IOdata Arraylistpolygon(int i)
        {
            return (IOdata)obj[i];
        }

        //get diamond information freom arraylist
        private Condition Arraylistdiamond(int i)
        {
            return (Condition)obj[i];
        }

        private line Arraylistline(int i)
        {
            return (line)obj[i];
        }

        // write on file 
        public void WriteXml(string path)
        {
            FileStream f = null;
            try
            {
                f = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter s1 = new StreamWriter(f);

                //write the string to the current stream
                s1.WriteLine("<Work_Flow>");

                for (int i = 0; i < obj.Count; i++)
                {
                    switch (obj[i].ToString())
                    {


                        case "IOdata":
                            s1.WriteLine("<shape>");
                            s1.WriteLine("<Name>" + Arraylistpolygon(i).getName() + "</Name>");
                            s1.WriteLine("<StartX>" + Arraylistpolygon(i).get_startX() + "</StartX>");
                            s1.WriteLine("<StartY>" + Arraylistpolygon(i).get_startY() + "</StartY>");
                            s1.WriteLine("<EndX>" + Arraylistpolygon(i).get_endX() + "</EndX>");
                            s1.WriteLine("<EndY>" + Arraylistpolygon(i).get_endY() + "</EndY>");
                            s1.WriteLine("<Caption>" + Arraylistpolygon(i).getCaption() + "</Caption>");
                            s1.WriteLine("<Duration>" + Arraylistpolygon(i).getDuration() + "</Duration>");
                            s1.WriteLine("<exprssion>" + " " + "</exprssion>");
                            s1.WriteLine("<number_of_parameter>" + " "+ "</number_of_parameter>");
                            s1.WriteLine("<type_of_parameter>" + " " + "</type_of_parameter>");
                            s1.WriteLine("<ID>" + Arraylistpolygon(i).getIDP() + "</ID>");
                            s1.WriteLine("</shape>");
                            break;

                        case "StartEnd":
                            s1.WriteLine("<shape>");
                            s1.WriteLine("<Name>" + Arraylistellipse(i).getName() + "</Name>");
                            s1.WriteLine("<StartX>" + Arraylistellipse(i).get_startX() + "</StartX>");
                            s1.WriteLine("<StartY>" + Arraylistellipse(i).get_startY() + "</StartY>");
                            s1.WriteLine("<EndX>" + Arraylistellipse(i).get_endX() + "</EndX>");
                            s1.WriteLine("<EndY>" + Arraylistellipse(i).get_endY() + "</EndY>");
                            s1.WriteLine("<Caption>" + Arraylistellipse(i).getCaption() + "</Caption>");
                            s1.WriteLine("<Duration>" + Arraylistellipse(i).getDuration() + "</Duration>");
                            s1.WriteLine("<exprssion>" + " " + "</exprssion>");
                            s1.WriteLine("<number_of_parameter>" + " " + "</number_of_parameter>");
                            s1.WriteLine("<type_of_parameter>" + " " + "</type_of_parameter>");
                            s1.WriteLine("<ID>" + Arraylistellipse(i).getIDE() + "</ID>");
                            s1.WriteLine("</shape>");
                            break;

                        case "Condition":
                            s1.WriteLine("<shape>");
                            s1.WriteLine("<Name>" + Arraylistdiamond(i).getName() + "</Name>");
                            s1.WriteLine("<StartX>" + Arraylistdiamond(i).get_startX() + "</StartX>");
                            s1.WriteLine("<StartY>" + Arraylistdiamond(i).get_startY() + "</StartY>");
                            s1.WriteLine("<EndX>" + Arraylistdiamond(i).get_endX() + "</EndX>");
                            s1.WriteLine("<EndY>" + Arraylistdiamond(i).get_endY() + "</EndY>");
                            s1.WriteLine("<Caption>" + Arraylistdiamond(i).getCaption() + "</Caption>");
                            s1.WriteLine("<Duration>" + Arraylistdiamond(i).getDuration() + "</Duration>");
                            //s1.WriteLine("<parameter>");
                            s1.WriteLine("<exprssion>" + Arraylistdiamond(i).getCaption() + "</exprssion>");
                            s1.WriteLine("<number_of_parameter>" + Arraylistdiamond(i).get_NoOfP() + "</number_of_parameter>");
                            s1.WriteLine("<type_of_parameter>" + Arraylistdiamond(i).get_type() + "</type_of_parameter>");
                            //s1.WriteLine("</parameter>");
                            s1.WriteLine("<ID>" + Arraylistdiamond(i).getIDD() + "</ID>");
                            s1.WriteLine("</shape>");
                            break;

                        case "Process":
                            s1.WriteLine("<shape>");
                            s1.WriteLine("<Name>" + Arraylistrectangle(i).getName() + "</Name>");
                            s1.WriteLine("<StartX>" + Arraylistrectangle(i).get_startX() + "</StartX>");
                            s1.WriteLine("<StartY>" + Arraylistrectangle(i).get_startY() + "</StartY>");
                            s1.WriteLine("<EndX>" + Arraylistrectangle(i).get_endX() + "</EndX>");
                            s1.WriteLine("<EndY>" + Arraylistrectangle(i).get_endY() + "</EndY>");
                            s1.WriteLine("<Caption>" + Arraylistrectangle(i).getCaption() + "</Caption>");
                            s1.WriteLine("<Duration>" + Arraylistrectangle(i).getDuration() + "</Duration>");
                            s1.WriteLine("<exprssion>" + " " + "</exprssion>");
                            s1.WriteLine("<number_of_parameter>" + " " + "</number_of_parameter>");
                            s1.WriteLine("<type_of_parameter>" + " " + "</type_of_parameter>");
                            s1.WriteLine("<ID>" + Arraylistrectangle(i).getIDR() + "</ID>");
                            s1.WriteLine("</shape>");
                            break;

                        case "line":
                            s1.WriteLine("<shape>");
                            s1.WriteLine("<Name>" + Arraylistline(i).get_name() + "</Name>");
                            s1.WriteLine("<StartX>" + Arraylistline(i).get_startX() + "</StartX>");
                            s1.WriteLine("<StartY>" + Arraylistline(i).get_startY() + "</StartY>");
                            s1.WriteLine("<EndX>" + Arraylistline(i).get_endX() + "</EndX>");
                            s1.WriteLine("<EndY>" + Arraylistline(i).get_endY() + "</EndY>");
                            s1.WriteLine("<Caption>" +" "+ "</Caption>");
                            s1.WriteLine("<Duration>" + " " + "</Duration>");
                            s1.WriteLine("<exprssion>" + " " + "</exprssion>");
                            s1.WriteLine("<number_of_parameter>" + " "  + "</number_of_parameter>");
                            s1.WriteLine("<type_of_parameter>" + " " + "</type_of_parameter>");
                            s1.WriteLine("<ID>" + " " + "</ID>");
                            s1.WriteLine("</shape>");
                            break;

                    }

                }
                s1.WriteLine("</Work_Flow>");
                s1.Flush(); //clear all buffers for current writer
                s1.Close();//close the currunt stream object
                f.Close();

            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (f != null)
                {
                    f.Close();
                }
            }
        }

        // read form file
        void readXML(string path)
        {

            FileStream Reader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument document = new XmlDocument();
            document.Load(Reader);

            try
            {
            
                System.Xml.XmlNodeList NodeList_name = document.GetElementsByTagName("Name");
                System.Xml.XmlNodeList NodeList_SPx = document.GetElementsByTagName("StartX");
                System.Xml.XmlNodeList NodeList_EPx = document.GetElementsByTagName("EndX");
                System.Xml.XmlNodeList NodeList_SPy = document.GetElementsByTagName("StartY");
                System.Xml.XmlNodeList NodeList_EPy = document.GetElementsByTagName("EndY");
                System.Xml.XmlNodeList NodeList_C = document.GetElementsByTagName("Caption");
                System.Xml.XmlNodeList NodeList_D = document.GetElementsByTagName("Duration");
                System.Xml.XmlNodeList NodeList_exp = document.GetElementsByTagName("exprssion");
                System.Xml.XmlNodeList NodeList_nop = document.GetElementsByTagName("number_of_parameter");
                System.Xml.XmlNodeList NodeList_top = document.GetElementsByTagName("type_of_parameter");
                System.Xml.XmlNodeList NodeList_ID = document.GetElementsByTagName("ID");

                obj.Clear();

                Graphics gg = base.CreateGraphics();

                for (int i = 0; i < NodeList_name.Count; i++)
                {
                    string name = NodeList_name[i].InnerText;

                    string stx = NodeList_SPx[i].InnerText;
                    string edx = NodeList_EPx[i].InnerText;
                    string sty = NodeList_SPy[i].InnerText;
                    string edy = NodeList_EPy[i].InnerText;
                    int right_stx = int.Parse(stx);
                    int right_edx = int.Parse(edx);
                    int right_sty = int.Parse(sty);
                    int right_edy = int.Parse(edy);

                        string caption1 = NodeList_C[i].InnerText;
                        string duration = NodeList_D[i].InnerText;
                        string id = NodeList_ID[i].InnerText;
                        string exp = NodeList_exp[i].InnerText;
                        string nop = NodeList_nop[i].InnerText;
                        string top = NodeList_top[i].InnerText;

                        if (name == "StartEnd")
                        {
                            ee = new StartEnd();

                            int right_Duration = int.Parse(duration);
                            int right_ID = int.Parse(id);

                            ee.setStartP(right_stx, right_sty);
                            ee.setEndP(right_edx, right_edy);
                            ee.set(caption1, right_Duration);
                            ee.setIDE(right_ID);
                            ee.drawE(gg);
                            obj.Add(ee);

                        }

                        else if (name == "IOdata")
                        {

                            p = new IOdata();

                            int right_Duration = int.Parse(duration);
                            int right_ID = int.Parse(id);

                            p.setStartP(right_stx, right_sty);
                            p.setEndP(right_edx, right_edy);
                            p.set(caption1, right_Duration);
                            p.setIDP(right_ID);
                            p.drawP(gg);
                            obj.Add(p);

                        }

                        else if (name == "Condition")
                        { 
                            d = new Condition();

                            int right_Duration = int.Parse(duration);
                            int right_ID = int.Parse(id);
                            int right_nop = int.Parse(nop);

                            d.setStartP(right_stx, right_sty);
                            d.setEndP(right_edx, right_edy);
                            d.set(exp, right_Duration);
                            d.setIDD(right_ID);
                            d.setCondition(right_nop, top);
                            d.drawD(gg);
                            obj.Add(d);
                        }

                        else if (name == "Process")
                        {
                            r = new Process();

                            int right_Duration = int.Parse(duration);
                            int right_ID = int.Parse(id);
 
                            r.setStartP(right_stx, right_sty);
                            r.setEndP(right_edx, right_edy);
                            r.set(caption1, right_Duration);
                            r.setIDR(right_ID);
                            r.drawR(gg);
                            obj.Add(r);
                        }

                    else if (name == "Line")
                    {
                        l = new line();
                        l.setStartP(right_stx, right_sty);
                        l.setEndP(right_edx, right_edy);
                        l.drawL(gg);
                        obj.Add(l);
                    }
                    
                }
                Reader.Close();
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (Reader != null)
                {
                    Reader.Close();
                }
            }
            
        }
        


        void activate()
        {
            groupBox1.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            toolStripButton7.Enabled = true;
            toolStripButton8.Enabled = true;
            toolStripButton3.Enabled = true;
            editToolStripMenuItem1.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            polygonToolStripMenuItem.Enabled = true;
            diToolStripMenuItem.Enabled = true;
            lineToolStripMenuItem.Enabled = true;
            rectangleToolStripMenuItem.Enabled = true;
            button1.Enabled = false;
        }
        void disactivate()
        {
            groupBox1.Enabled = false;
            toolStripButton5.Enabled = false;
            toolStripButton6.Enabled = false;
            toolStripButton7.Enabled = false;
            toolStripButton8.Enabled = false;
            toolStripButton3.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            polygonToolStripMenuItem.Enabled = false;
            diToolStripMenuItem.Enabled = false;
            lineToolStripMenuItem.Enabled = false;
            rectangleToolStripMenuItem.Enabled = false;
        }
        void condition_activate()
        {
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
        }

        void condition_disactivate()
        {
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
        }
        private void space()///to make textbox prepared to enter new data 
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        void save()
        {

            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "XML File|*.xml";
            s.Title = "save XML file";
            DialogResult res = s.ShowDialog();
            if (res == DialogResult.Cancel)
                return;
            string path = s.FileName;
            WriteXml(path);
            if (saveButton == true)
                Application.Exit();

        }
        void open()
        {
            DialogResult result = MessageBox.Show("Save the changes? ", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                save();
            }

            else if (result == DialogResult.No)
            {
                Invalidate();
                OpenFileDialog o = new OpenFileDialog();
                o.Filter = "XMl File|*.xml";
                o.Title = "open XML file";
                DialogResult res = o.ShowDialog();
                if (res == DialogResult.Cancel)
                    return;
                string path = o.FileName;
                readXML(path);

            }


        }
        void newf()
        {
            saveButton = false;

            DialogResult result = MessageBox.Show("Save the changes? ", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                save();
                Application.Restart();

            }
            else if (result == DialogResult.No)
            {
                disactivate(); // to return as start form
                Application.Restart();
            }
        }
        void exit()
        {
            DialogResult result = MessageBox.Show("Save the changes? ", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                save();
            }
            else if (result == DialogResult.No)
                Application.Exit();
        }

        # endregion

        # region events

        public void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            edit_x = e.X;
            edit_y = e.Y;
            switch (m)
            {
                case 1:

                    ee.setStartP(e.X, e.Y);
                    break;
                case 2:

                    p.setStartP(e.X, e.Y);
                    break;
                case 3:

                    d.setStartP(e.X, e.Y);
                    break;
                case 4:

                    r.setStartP(e.X, e.Y);
                    break;
                case 5:

                    l.setStartP(e.X, e.Y);
                    break;
            }
        }

        public void Form1_MouseUp(object sender, MouseEventArgs e)
        {


            Graphics g = base.CreateGraphics();
            switch (m)
            {
                case 1:
                    ee.setEndP(e.X, e.Y);
                    ee.drawE(g);
                    textBox1.Text = ee.getName();
                    activate();
                    condition_disactivate();
                    mm = m;
                    m = 0;
                    break;
                case 2:
                    p.setEndP(e.X, e.Y);
                    p.drawP(g);
                    textBox1.Text = p.getName();
                    textBox2.Enabled = true;
                    activate();
                    condition_disactivate();
                    mm = m;
                    m = 0;
                    break;
                case 3:
                    d.setEndP(e.X, e.Y);
                    d.drawD(g);
                    textBox1.Text = d.getName();
                    textBox2.Enabled = false;
                    activate();
                    condition_activate();
                    mm = m;
                    m = 0;
                    break;
                case 4:
                    r.setEndP(e.X, e.Y);
                    r.drawR(g);
                    textBox1.Text = r.getName();
                    textBox2.Enabled = true;
                    activate();
                    condition_disactivate();
                    mm = m;
                    m = 0;
                    break;
                case 5:
                    l.setEndP(e.X, e.Y);
                    groupBox1.Enabled = false;
                    l.drawL(g);
                    obj.Add(l);
                    m = 0;
                    break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            obj.Clear();
            textBox1.ReadOnly = true;
            textBox4.ReadOnly = true;
            disactivate();




        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ee = new StartEnd();
            m = 1;
            textBox4.Text = Convert.ToString(ee.IDReturn());

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            p = new IOdata();
            m = 2;
            textBox4.Text = Convert.ToString(p.IDReturn());


        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            d = new Condition();
            m = 3;
            textBox4.Text = Convert.ToString(d.IDReturn());


        }


        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            r = new Process();
            m = 4;
            textBox4.Text = Convert.ToString(r.IDReturn());

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            l = new line();
            m = 5;
            space();
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ee = new StartEnd();
            m = 1;
            textBox4.Text = Convert.ToString(ee.IDReturn());

        }

        private void polygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p = new IOdata();
            m = 2;
            textBox4.Text = Convert.ToString(p.IDReturn());

        }

        private void diToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d = new Condition();
            m = 3;
            textBox4.Text = Convert.ToString(d.IDReturn());

        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            r = new Process();
            m = 4;
            textBox4.Text = Convert.ToString(r.IDReturn());

        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m = 5;
            space();

        }


        public void button1_Click(object sender, EventArgs e)
        {
            int days;

            switch (mm)
            {
                case 1:
                    days = int.Parse(textBox3.Text);
                    if (edit_index == 0)
                    {
                        ee.set(textBox2.Text, days);
                        obj.Add(ee);
                    }
                    else

                        Arraylistellipse(edit_index).set(textBox2.Text, days);

                    break;
                case 2:
                    days = int.Parse(textBox3.Text);
                    if (edit_index == 0)
                    {
                        p.set(textBox2.Text, days);
                        obj.Add(p);
                    }
                    else
                        Arraylistpolygon(edit_index).set(textBox2.Text, days);
                    break;
                case 3:
                    days = int.Parse(textBox3.Text);
                    int numberofP = int.Parse(textBox6.Text);
                    if (edit_index == 0)
                    {
                        d.set(textBox5.Text, days);
                        d.setCondition(numberofP, textBox7.Text);
                        obj.Add(d);
                    }
                    else
                    {
                        Arraylistdiamond(edit_index).set(textBox5.Text, days);
                        Arraylistdiamond(edit_index).setCondition(numberofP, textBox7.Text);
                    }
                    break;
                case 4:
                    days = int.Parse(textBox3.Text);
                    if (edit_index == 0)
                    {
                        r.set(textBox2.Text, days);
                        obj.Add(r);
                    }
                    else
                        Arraylistrectangle(edit_index).set(textBox2.Text, days);
                    break;

            }

            space();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            newf();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newf();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            open();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            save();
        }

        private void aboutTheProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 f = new Form2();
            f.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (textBox3.Text == "")
                button1.Enabled = false;

        }


        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                switch (obj[i].ToString())
                {
                    case "StartEnd":
                        if (edit_x >= Arraylistellipse(i).get_startX() && edit_x <= Arraylistellipse(i).get_endX() && edit_y >= Arraylistellipse(i).get_startY() && edit_y <= Arraylistellipse(i).get_endY()
                            || (edit_x <= Arraylistellipse(i).get_startX() && edit_x >= Arraylistellipse(i).get_endX() && edit_y <= Arraylistellipse(i).get_startY() && edit_y >= Arraylistellipse(i).get_endY())
                            || (edit_x <= Arraylistellipse(i).get_startX() && edit_x >= Arraylistellipse(i).get_endX() && edit_y >= Arraylistellipse(i).get_startY() && edit_y <= Arraylistellipse(i).get_endY())
                            || (edit_x >= Arraylistellipse(i).get_startX() && edit_x <= Arraylistellipse(i).get_endX() && edit_y <= Arraylistellipse(i).get_startY() && edit_y >= Arraylistellipse(i).get_endY()))
                        {
                            textBox2.Enabled = true;
                            activate();
                            condition_disactivate();
                            space();
                            mm = 1;
                            edit_index = i;
                            textBox1.Text = Arraylistellipse(i).getName();
                            textBox2.Text = Arraylistellipse(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistellipse(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistellipse(i).getIDE());


                        }
                        break;
                    case "Process":
                        if (edit_x >= Arraylistrectangle(i).get_startX() && edit_x <= Arraylistrectangle(i).get_endX() && edit_y >= Arraylistrectangle(i).get_startY() && edit_y <= Arraylistrectangle(i).get_endY()
                            || (edit_x <= Arraylistrectangle(i).get_startX() && edit_x >= Arraylistrectangle(i).get_endX() && edit_y <= Arraylistrectangle(i).get_startY() && edit_y >= Arraylistrectangle(i).get_endY())
                            || (edit_x <= Arraylistrectangle(i).get_startX() && edit_x >= Arraylistrectangle(i).get_endX() && edit_y >= Arraylistrectangle(i).get_startY() && edit_y <= Arraylistrectangle(i).get_endY())
                            || (edit_x >= Arraylistrectangle(i).get_startX() && edit_x <= Arraylistrectangle(i).get_endX() && edit_y <= Arraylistrectangle(i).get_startY() && edit_y >= Arraylistrectangle(i).get_endY()))
                        {
                            textBox2.Enabled = true;
                            activate();
                            condition_disactivate();
                            space();
                            mm = 4;
                            edit_index = i;
                            textBox1.Text = Arraylistrectangle(i).getName();
                            textBox2.Text = Arraylistrectangle(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistrectangle(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistrectangle(i).getIDR());


                        }
                        break;
                    case "IOdata":
                        if (edit_x >= Arraylistpolygon(i).get_startX() && edit_x <= Arraylistpolygon(i).get_endX() && edit_y >= Arraylistpolygon(i).get_startY() && edit_y <= Arraylistpolygon(i).get_endY()
                            || (edit_x <= Arraylistpolygon(i).get_startX() && edit_x >= Arraylistpolygon(i).get_endX() && edit_y <= Arraylistpolygon(i).get_startY() && edit_y >= Arraylistpolygon(i).get_endY())
                            || (edit_x <= Arraylistpolygon(i).get_startX() && edit_x >= Arraylistpolygon(i).get_endX() && edit_y >= Arraylistpolygon(i).get_startY() && edit_y <= Arraylistpolygon(i).get_endY())
                            || (edit_x >= Arraylistpolygon(i).get_startX() && edit_x <= Arraylistpolygon(i).get_endX() && edit_y <= Arraylistpolygon(i).get_startY() && edit_y >= Arraylistpolygon(i).get_endY()))
                        {
                            textBox2.Enabled = true;
                            activate();
                            condition_disactivate();
                            space();
                            mm = 2;
                            edit_index = i;
                            textBox1.Text = Arraylistpolygon(i).getName();
                            textBox2.Text = Arraylistpolygon(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistpolygon(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistpolygon(i).getIDP());


                        }
                        break;
                    case "Condition":
                        if (edit_x >= Arraylistdiamond(i).get_startX() && edit_x <= Arraylistdiamond(i).get_endX() && edit_y >= Arraylistdiamond(i).get_startY() && edit_y <= Arraylistdiamond(i).get_endY()
                            || (edit_x <= Arraylistdiamond(i).get_startX() && edit_x >= Arraylistdiamond(i).get_endX() && edit_y <= Arraylistdiamond(i).get_startY() && edit_y >= Arraylistdiamond(i).get_endY())
                            || (edit_x <= Arraylistdiamond(i).get_startX() && edit_x >= Arraylistdiamond(i).get_endX() && edit_y >= Arraylistdiamond(i).get_startY() && edit_y <= Arraylistdiamond(i).get_endY())
                            || (edit_x >= Arraylistdiamond(i).get_startX() && edit_x <= Arraylistdiamond(i).get_endX() && edit_y <= Arraylistdiamond(i).get_startY() && edit_y >= Arraylistdiamond(i).get_endY()))
                        {
                            textBox2.Enabled = false;
                            activate();
                            condition_activate();
                            space();
                            mm = 3;
                            edit_index = i;
                            textBox1.Text = Arraylistdiamond(i).getName();
                            textBox5.Text = Arraylistdiamond(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistdiamond(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistdiamond(i).getIDD());
                            textBox6.Text = Convert.ToString(Arraylistdiamond(i).get_NoOfP());
                            textBox7.Text = Arraylistdiamond(i).get_type();



                        }
                        break;

                }

            }
        }

       

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < obj.Count; i++)
            {
                switch (obj[i].ToString())
                {
                    case "StartEnd":
                        if (edit_x >= Arraylistellipse(i).get_startX() && edit_x <= Arraylistellipse(i).get_endX() && edit_y >= Arraylistellipse(i).get_startY() && edit_y <= Arraylistellipse(i).get_endY()
                            || (edit_x <= Arraylistellipse(i).get_startX() && edit_x >= Arraylistellipse(i).get_endX() && edit_y <= Arraylistellipse(i).get_startY() && edit_y >= Arraylistellipse(i).get_endY())
                            || (edit_x <= Arraylistellipse(i).get_startX() && edit_x >= Arraylistellipse(i).get_endX() && edit_y >= Arraylistellipse(i).get_startY() && edit_y <= Arraylistellipse(i).get_endY())
                            || (edit_x >= Arraylistellipse(i).get_startX() && edit_x <= Arraylistellipse(i).get_endX() && edit_y <= Arraylistellipse(i).get_startY() && edit_y >= Arraylistellipse(i).get_endY()))
                        {

                            mm = 1;

                            edit_index = i;
                            textBox1.Text = Arraylistellipse(i).getName();
                            textBox2.Text = Arraylistellipse(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistellipse(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistellipse(i).getIDE());
                            Graphics g = base.CreateGraphics();
                            Pen myPen = new Pen(Color.White);
                            SolidBrush brush = new SolidBrush(Color.White);
                            Arraylistellipse(i).drawE(g, myPen, brush);
                            obj.RemoveAt(i);

                        }
                        break;
                    case "Process":
                        if (edit_x >= Arraylistrectangle(i).get_startX() && edit_x <= Arraylistrectangle(i).get_endX() && edit_y >= Arraylistrectangle(i).get_startY() && edit_y <= Arraylistrectangle(i).get_endY()
                            || (edit_x <= Arraylistrectangle(i).get_startX() && edit_x >= Arraylistrectangle(i).get_endX() && edit_y <= Arraylistrectangle(i).get_startY() && edit_y >= Arraylistrectangle(i).get_endY())
                            || (edit_x <= Arraylistrectangle(i).get_startX() && edit_x >= Arraylistrectangle(i).get_endX() && edit_y >= Arraylistrectangle(i).get_startY() && edit_y <= Arraylistrectangle(i).get_endY())
                            || (edit_x >= Arraylistrectangle(i).get_startX() && edit_x <= Arraylistrectangle(i).get_endX() && edit_y <= Arraylistrectangle(i).get_startY() && edit_y >= Arraylistrectangle(i).get_endY()))
                        {

                            textBox1.Text = Arraylistrectangle(i).getName();
                            textBox2.Text = Arraylistrectangle(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistrectangle(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistrectangle(i).getIDR());
                            Graphics g = base.CreateGraphics();
                            Pen myPen = new Pen(Color.White);
                            SolidBrush brush = new SolidBrush(Color.White);
                            Arraylistrectangle(i).drawR(g, myPen, brush);
                            obj.RemoveAt(i);
                        }
                        break;
                    case "IOdata":
                        if (edit_x >= Arraylistpolygon(i).get_startX() && edit_x <= Arraylistpolygon(i).get_endX() && edit_y >= Arraylistpolygon(i).get_startY() && edit_y <= Arraylistpolygon(i).get_endY()
                            || (edit_x <= Arraylistpolygon(i).get_startX() && edit_x >= Arraylistpolygon(i).get_endX() && edit_y <= Arraylistpolygon(i).get_startY() && edit_y >= Arraylistpolygon(i).get_endY())
                            || (edit_x <= Arraylistpolygon(i).get_startX() && edit_x >= Arraylistpolygon(i).get_endX() && edit_y >= Arraylistpolygon(i).get_startY() && edit_y <= Arraylistpolygon(i).get_endY())
                            || (edit_x >= Arraylistpolygon(i).get_startX() && edit_x <= Arraylistpolygon(i).get_endX() && edit_y <= Arraylistpolygon(i).get_startY() && edit_y >= Arraylistpolygon(i).get_endY()))
                        {

                            textBox1.Text = Arraylistpolygon(i).getName();
                            textBox2.Text = Arraylistpolygon(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistpolygon(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistpolygon(i).getIDP());
                            Graphics g = base.CreateGraphics();
                            Pen myPen = new Pen(Color.White);
                            SolidBrush brush = new SolidBrush(Color.White);
                            Arraylistpolygon(i).drawP(g, myPen, brush);
                            obj.RemoveAt(i);
                        }
                        break;
                    case "Condition":
                        if (edit_x >= Arraylistdiamond(i).get_startX() && edit_x <= Arraylistdiamond(i).get_endX() && edit_y >= Arraylistdiamond(i).get_startY() && edit_y <= Arraylistdiamond(i).get_endY()
                            || (edit_x <= Arraylistdiamond(i).get_startX() && edit_x >= Arraylistdiamond(i).get_endX() && edit_y <= Arraylistdiamond(i).get_startY() && edit_y >= Arraylistdiamond(i).get_endY())
                            || (edit_x <= Arraylistdiamond(i).get_startX() && edit_x >= Arraylistdiamond(i).get_endX() && edit_y >= Arraylistdiamond(i).get_startY() && edit_y <= Arraylistdiamond(i).get_endY())
                            || (edit_x >= Arraylistdiamond(i).get_startX() && edit_x <= Arraylistdiamond(i).get_endX() && edit_y <= Arraylistdiamond(i).get_startY() && edit_y >= Arraylistdiamond(i).get_endY()))
                        {

                            textBox1.Text = Arraylistdiamond(i).getName();
                            textBox5.Text = Arraylistdiamond(i).getCaption();
                            textBox3.Text = Convert.ToString(Arraylistdiamond(i).getDuration());
                            textBox4.Text = Convert.ToString(Arraylistdiamond(i).getIDD());
                            textBox6.Text = Convert.ToString(Arraylistdiamond(i).get_NoOfP());
                            textBox7.Text = Arraylistdiamond(i).get_type();
                            Graphics g = base.CreateGraphics();
                            Pen myPen = new Pen(Color.White, 2);
                            Arraylistdiamond(i).drawD(g, myPen);
                            obj.RemoveAt(i);
                        }
                        break;
                    case "line":
                        if (edit_x >= Arraylistline(i).get_startX() && edit_x <= Arraylistline(i).get_endX() && edit_y >= Arraylistline(i).get_startY() && edit_y <= Arraylistline(i).get_endY())
                        {
                            Graphics g = base.CreateGraphics();
                            Pen myPen = new Pen(Color.White, 2);
                            Arraylistline(i).drawL(g, myPen);
                            obj.RemoveAt(i);
                        }
                        break;


                }

            }

        }


        # endregion

    }
}

# region classes

class Node
{
    protected int startx, starty;
    protected int endx, endy;
    protected string name;
    protected string caption;
    protected int duration;
    protected static int ID = 1;

    public void setStartP(int sx, int sy)
    {
        startx = sx;
        starty = sy;
    }

    public void setEndP(int ex, int ey)
    {

        endx = ex;
        endy = ey;
    }
    public int get_startX()
    {
        return startx;
    }
    public int get_startY()
    {
        return starty;
    }
    public int get_endX()
    {
        return endx;
    }
    public int get_endY()
    {
        return endy;
    }


    public void set(string c, int d)
    {
        caption = c;
        duration = d;

        ID++;
    }
    public int IDReturn()
    {
        return ID;
    }


    public string getName()
    {
        return name;
    }
    public string getCaption()
    {
        return caption;
    }
    public float getDuration()
    {
        return duration;
    }

}
class StartEnd : Node
{
    private int IDE;
    public StartEnd()
    {
        name = "StartEnd";
    }

    public void setIDE(int id)
    {
        IDE = id;
    }

    public int getIDE()
    {
        return IDE;
    }


    public void drawE(Graphics g)
    {

        Pen myPen = new Pen(Color.Black, 1);
        SolidBrush redrush = new SolidBrush(Color.Pink);
        g.FillEllipse(redrush, startx, starty, (endx - startx), (endy - starty));

        if (startx < endx && starty < endy)
            g.DrawEllipse(myPen, startx, starty, (endx - startx), (endy - starty));
        else if (startx > endx && starty > endy)
            g.DrawEllipse(myPen, endx, endy, (startx - endx), (starty - endy));
        else if (startx > endx && endy > starty)
            g.DrawEllipse(myPen, endx, starty, (startx - endx), (endy - starty));
        else if (startx < endx && starty > endy)
            g.DrawEllipse(myPen, startx, endy, (endx - startx), (starty - endy));
        IDE = ID;

    }
    public void drawE(Graphics g, Pen myPen, SolidBrush redrush)
    {
        g.FillEllipse(redrush, startx, starty, (endx - startx), (endy - starty));

        if (startx < endx && starty < endy)
            g.DrawEllipse(myPen, startx, starty, (endx - startx), (endy - starty));
        else if (startx > endx && starty > endy)
            g.DrawEllipse(myPen, endx, endy, (startx - endx), (starty - endy));
        else if (startx > endx && endy > starty)
            g.DrawEllipse(myPen, endx, starty, (startx - endx), (endy - starty));
        else if (startx < endx && starty > endy)
            g.DrawEllipse(myPen, startx, endy, (endx - startx), (starty - endy));
        IDE = ID;
    }

}

class Process : Node
{
    private int IDR;
    public Process()
    {
        name = "Process";
    }
    public void setIDR(int id)
    {
        IDR = id;
    }

    public int getIDR()
    {
        return IDR;
    }

    public void drawR(Graphics g)
    {
        Pen myPen = new Pen(Color.Black, 1);
        SolidBrush redrush = new SolidBrush(Color.RoyalBlue);


        if (startx < endx && starty < endy)
        {
            g.FillRectangle(redrush, startx, starty, (endx - startx), (endy - starty));
            g.DrawRectangle(myPen, startx, starty, (endx - startx), (endy - starty));
        }
        else if (startx > endx && starty > endy)
        {
            g.FillRectangle(redrush, endx, endy, (startx - endx), (starty - endy));
            g.DrawRectangle(myPen, endx, endy, (startx - endx), (starty - endy));
        }
        else if (startx > endx && endy > starty)
        {
            g.FillRectangle(redrush, endx, starty, (startx - endx), (endy - starty));
            g.DrawRectangle(myPen, endx, starty, (startx - endx), (endy - starty));
        }
        else if (startx < endx && starty > endy)
        {
            g.FillRectangle(redrush, startx, endy, (endx - startx), (starty - endy));
            g.DrawRectangle(myPen, startx, endy, (endx - startx), (starty - endy));
        }
        IDR = ID;

    }
    public void drawR(Graphics g, Pen myPen, SolidBrush redrush)
    {

        if (startx < endx && starty < endy)
        {
            g.FillRectangle(redrush, startx, starty, (endx - startx), (endy - starty));
            g.DrawRectangle(myPen, startx, starty, (endx - startx), (endy - starty));
        }
        else if (startx > endx && starty > endy)
        {
            g.FillRectangle(redrush, endx, endy, (startx - endx), (starty - endy));
            g.DrawRectangle(myPen, endx, endy, (startx - endx), (starty - endy));
        }
        else if (startx > endx && endy > starty)
        {
            g.FillRectangle(redrush, endx, starty, (startx - endx), (endy - starty));
            g.DrawRectangle(myPen, endx, starty, (startx - endx), (endy - starty));
        }
        else if (startx < endx && starty > endy)
        {
            g.FillRectangle(redrush, startx, endy, (endx - startx), (starty - endy));
            g.DrawRectangle(myPen, startx, endy, (endx - startx), (starty - endy));
        }
        IDR = ID;
    }
}

class IOdata : Node
{
    private int IDP;
    public IOdata()
    {
        name = "IOdata";
    }

    public void setIDP(int id)
    {
        IDP = id;
    }

    public int getIDP()
    {
        return IDP;
    }
    public void drawP(Graphics g)
    {
        SolidBrush redrush = new SolidBrush(Color.Aqua);
        Pen b = new Pen(Color.Black);
        Point[] pp = new Point[4];

        pp[0] = new Point(startx, starty);
        pp[1] = new Point(endx, starty); pp[2] = new Point(endx - 30, endy); pp[3] = new Point(startx - 30, endy);
        g.FillPolygon(redrush, pp);
        g.DrawPolygon(b, pp);
        IDP = ID;

    }
    public void drawP(Graphics g, Pen b, SolidBrush redrush)
    {
        Point[] pp = new Point[4];

        pp[0] = new Point(startx, starty);
        pp[1] = new Point(endx, starty); pp[2] = new Point(endx - 30, endy); pp[3] = new Point(startx - 30, endy);
        g.FillPolygon(redrush, pp);
        g.DrawPolygon(b, pp);
        IDP = ID;
    }

}

class Condition : Node
{
    private int numberOfParameter;
    private string type;
    private int IDD;

    public Condition()
    {
        name = "Condition";
    }

    public void setCondition(int n, string t)
    {
        numberOfParameter = n;
        type = t;
    }


    public int getIDD()
    {
        return IDD;
    }

    public void setIDD(int id)
    {
        IDD = id;
    }

    public string get_type()
    {
        return type;
    }

    public int get_NoOfP()
    {
        return numberOfParameter;

    }

    public void drawD(Graphics g)
    {

        Pen mypen = new Pen(Color.Blue, 2);

        int x = (endx - startx) / 2 + startx;
        int y = (endy - starty) / 2 + starty;
        int X = (startx - endx) / 2 + startx;

        g.DrawLine(mypen, startx, starty, x, y);
        g.DrawLine(mypen, x, y, startx, endy);
        g.DrawLine(mypen, startx, endy, X, y);
        g.DrawLine(mypen, X, y, startx, starty);

        IDD = ID;

    }
    public void drawD(Graphics g, Pen mypen)
    {

        int x = (endx - startx) / 2 + startx;
        int y = (endy - starty) / 2 + starty;
        int X = (startx - endx) / 2 + startx;

        g.DrawLine(mypen, startx, starty, x, y);
        g.DrawLine(mypen, x, y, startx, endy);
        g.DrawLine(mypen, startx, endy, X, y);
        g.DrawLine(mypen, X, y, startx, starty);

        IDD = ID;
    }
}

class merge : Node
{


}

class line
{
    int startx, endx, starty, endy;
    private string name;

    public line()
    {
        name = "Line";
    }

    public void setStartP(int sx, int sy)
    {
        startx = sx;
        starty = sy;
    }

    public void setEndP(int ex, int ey)
    {

        endx = ex;
        endy = ey;
    }


    public void drawL(Graphics g)
    {
        Pen myPen = new Pen(Color.Black, 2);
        g.DrawLine(myPen, startx, starty, endx, endy);

    }
    public void drawL(Graphics g, Pen myPen)
    {
        g.DrawLine(myPen, startx, starty, endx, endy);

    }
    public int get_startX()
    {
        return startx;
    }
    public int get_startY()
    {
        return starty;
    }
    public int get_endX()
    {
        return endx;
    }
    public int get_endY()
    {
        return endy;
    }

    public string get_name()
    {
        return name;
    }
}


# endregion

