using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WaveConvertNet;
using System.Collections;
using MultiPhoneCompare;




namespace RePowerV
{
    public partial class FormMain : Form
    {
/*------------------------------------------------------------------------------*/
        #region Custom Variables

        // 计算分贝值时候 使用平均能量(1)/使用最大值对应的能量(0)
        int flag_method = 1;
        // 标准db值
        double db0 = -13.0;

        String in_wav_dir;  // 输入wav（或文件夹）所在的目录
        List<string> srcList = new List<string>();
        List<string> tgtList = new List<string>();
        List<string> errList = new List<string>();
        string outputPath;
        int selectedChannelIn;
        int selectedChannelOut;
        int ignoreSample;
        double frametime = 0.02;   //帧长（s）
        #endregion
        List<string> lstFile = new List<string>();
        // zhiming
        #region Custom Functions
        private void SetAllEnabled(bool value)
        {
            
            btTgt.Enabled = value;
           
            nUDChnIn.Enabled = value;
            nUDChnOut.Enabled = value;
            btOut.Enabled = value;
            tBOut.Enabled = value;
        }
        // double WINDOW = 0.02;
double  WINDOW_SLIP = 0.01;
int     stt         = 0;
        private void ReportProgress(int srcIndex, int tgtIndex, string message)
        {
            bgWDoWork.ReportProgress((srcIndex + tgtIndex) * 100 / (srcList.Count + tgtList.Count),
            String.Format("[{0}/{1}][{2}/{3}]{4}", srcIndex, srcList.Count, tgtIndex, tgtList.Count, message));
        }

        int Sgn(float sgndata)
        {
            if (sgndata > 0) return 1;
            if (sgndata < 0) return -1;
            else return 0;
        }
        /*取数组中绝对值最大函数*/
        float MaxIntAbs(float[] Buffer, int length)
        {
            float Max = (float)Math.Abs(Buffer[0]);
            for (int i = 1; i < length; i++)
            {
                if (Max < Math.Abs(Buffer[i]))
                    Max = (float)Math.Abs(Buffer[i]);
            }
            return Max;
        }
        /*预加重*/
        void PreEmphasize(float[] Speech, float[] PreAmp, int Samples)
        {
            PreAmp[0] = Speech[0];
            for (int i = 1; i < Samples; i++)
                PreAmp[i] = (float)(Speech[i] - 0.94 * Speech[i - 1]);
        }

        

/*--------------------------------------------------------------------------------------------------------------*/
     public struct item
    {
        public double st; 
        public double end;  
        public string text;
    }

     int read_yuanyin(String iFile, ref List<String> list_yy)
     {

         string str = "";
         if (File.Exists(iFile))
         {
             StreamReader sr = null;
             try
             {
                 sr = new StreamReader(iFile, System.Text.Encoding.UTF8);
                 while (sr.Peek() > 0)
                 {
                     str = sr.ReadLine();
                     //str = str.Replace("\"", "");
                     list_yy.Add(str);
                 }
             }
             catch
             { }
             finally
             {
                 if (sr != null)
                     sr.Close();
                 sr = null;
             }
         }
         else
             return -1;
         return 0;

     }

     int find_yy(List<String> list_yy, String str)
     {
         for (int ii = 0; ii < list_yy.Count; ii++ )
         {
             if (list_yy[ii].Equals(str))
             {
                 return 1;
             }
         }
         return 0;
     }

        int readInt(String iFile, ref List<item> list_item, List<String> list_yy)
        {
            //CInterval cit = new CInterval();
            int ret = 0;
            int laynum = 0;
            double time_all = 0.0;
            string str = "";
            item item_temp;

            if (File.Exists(iFile))
            {
                StreamReader sr = null;
                int n = 0;
                try
                {
                    sr = new StreamReader(iFile, System.Text.Encoding.UTF8);
              
                    while (n < 10 && sr.Peek() > 0)
                    {
                        str = sr.ReadLine();
                        n++;
                    }
                    str = sr.ReadLine();
                    time_all = double.Parse(str);
                    str = sr.ReadLine();
                    laynum = int.Parse(str);

                    n = 0;
                    while (n < laynum)
                    {
                       str = sr.ReadLine();
                       item_temp.st = double.Parse(str);
                       str = sr.ReadLine();
                       item_temp.end = double.Parse(str);
                       str = sr.ReadLine();
                       str = str.Replace("\"","");
                       item_temp.text = str;

                       int is_find = find_yy(list_yy,str);
                        if(is_find == 1)
                        {
                            list_item.Add(item_temp);
                         }
                       n = n + 1;
                       
                    }
                 }
                 catch
                 { }
                 finally
                 {
                    if (sr != null)
                        sr.Close();
                    sr = null;
                 }

            }
            else
                ret = -1;
            return ret;
  
        }



        double gstart = 0.0, gend = 0.0;
        /* 使用 韵母来计算平均能量 */
        double ExtractAmpFeats_int(short[,] data, int SampleRate, List<item> list_item)
        {
            int chnl = selectedChannelIn;
            int flen = (int)(SampleRate * frametime);              //帧长点数

            int num = list_item.Count;  // 所有元音总数
            //PowerZeroVAD(tdata, tdata.Length, stt * 2, stt, ref begin, ref end, ref num);
 
            GC.Collect();
            double temp = 0;
            if (chnl >= data.GetLength(0)) chnl = data.GetLength(0) - 1;
            if (chnl < 0) chnl = 0;

            double fAmpMean = 0;
            int sumf = 0;                       /*记录所有采样点数*/
            for (int ii = 0; ii < num; ii++)
            {
                double begin_temp = Convert.ToDouble(SampleRate) * list_item[ii].st;
                int begin = Convert.ToInt32(begin_temp);
                double end_temp = Convert.ToDouble(SampleRate) * list_item[ii].end;
                int end = Convert.ToInt32(end_temp);
                
                for (int j = begin; j < end; j++)
                {
                    sumf ++;
                    temp = (double)data[chnl, j] / 32768;
                    fAmpMean += temp * temp;                              //累加
                }
            }
            return fAmpMean / sumf;                                        //平均每个采样点能量
        }
 
        string GMSG = "";

        /*
         * 根据db值的分布 计算需要增益的db差值 
         */
        double get_db_gain(double db ,double db0)
        {
            double db_gain = 0;

            // 阶梯压缩

            /*
            // -13 到 -17 分别向靠拢到-17
            if (db < db0 - 4.0) // < -21
            {
                db_gain = 4.0;
            }
            else if(db > db0+4.0) // > -13
            {
                db_gain = -4.0;
            }
            */

            
            if (db < db0-4) // -21
                db_gain = 4;
            else if (db < db0-3) // -20
                db_gain = 2.5;
            else if (db < db0-2) // -19
                db_gain = 1.4;
            else if (db < db0-1) // -18 
                db_gain = 0.5;


            else if (db > db0+7) // -10
                db_gain = -5;  // 1.3
            else if (db > db0+6) // -11
                db_gain = -4.3;    // 1.0
            else if (db > db0+5) // -12
                db_gain = -3.9;     // 0.8
            else if (db > db0+4)  // -13
                db_gain = -3.5;   // 0.6
            else if (db > db0+3)
                db_gain = -2.3;
            else if (db > db0+2)
                db_gain = -0.8;
            else if (db > db0+1)
                db_gain = 0.0;
            

            return db_gain;
        }
        
        /* 
         * 从头开始扫描整个data 到过零点截止 得到一个小周期 进行调整
         * 周期内最大幅度值V  计算db值 
         * 大于17db的  减少4db
         * 小于17db的  增大4db 
         */
        int AdjustAmpX(ref short[,] data, int SampleRate)
        {
            double V0 = 32767.0;
            
            // data数据里面对应的channel 
            int chnl = selectedChannelOut;
            if (chnl >= data.GetLength(0))
            {
                chnl = data.GetLength(0) - 1;
            }
            if (chnl < 0)
            {
                chnl = 0;
            } 

            // 周期波形获取
            double factor = Math.Sqrt(0.09);
            //short[] data_period = null;
            // 最优边界 都是包含的
            int ii_left = 0;
            int ii_right = 0;
            
            for (int i = 1; i < data.GetLength(1); ++i)
            {
                // 前后两个采样点 正负
                if (data[chnl, i] > 0 && data[chnl,i-1] <=0 ||
                    data[chnl,i]<0 && data[chnl,i-1] >= 0 )
                {
                    ii_left = ii_right;
                    ii_right = i - 1;
                    double db = -17;

                    if (flag_method == 0)
                    {
                        //// 计算最大幅度值  对应的能量(分贝值)
                        double max_value = 1;
                        for (int jj = ii_left; jj <= ii_right; jj++)
                        {
                            if (Math.Abs(data[chnl, jj]) > max_value)
                            {
                                max_value = Math.Abs(data[chnl, jj]);
                            }
                        }
                        db = 10 * Math.Log10(Math.Pow(max_value/V0, 2));
                    }
                    else if (flag_method == 1)
                    {
                        // 计算平均能量(分贝值)
                        double power = 0.0;
                        for (int jj = ii_left; jj <= ii_right; jj++)
                        {
                            power += Math.Pow(data[chnl, jj] / V0, 2);
                        }
                        power = power / (ii_right - ii_left + 1);
                        db = 10 * Math.Log10(power);
                    }

                    //// 测试db值
                    //double time = ii_left / 48000.0;
                    //GMSG += "time= " + time.ToString() +"db=" + db.ToString() + "\r\n";

                    // -17db
                    // 大于 -21db  幅度值小 db值增加4db 
                    // 小于 -13db  幅度值大 db值减少4db 
                    // 幅度值调整比例 
                    double ratio = 1;
                    double db_gain = 0; // db增加 减少的值 

                    db_gain = get_db_gain(db,db0);

                    ratio = Math.Pow(10, db_gain / 20.0);
                    // 按照比例 将data数据 value值修改 
                    for (int jj = ii_left; jj <= ii_right; jj++)
                    {
                        data[chnl, jj] = (short)Math.Round(ratio*(double)data[chnl,jj]);
                    }

                    // 修改 左右边界保存值
                    ii_right = i;
                    
                }
            }
                      
                    
            return 0;
        }



        #endregion
/*------------------------------------------------------------------------------*/
        public FormMain()
        {
            InitializeComponent();
        }

        private void btOut_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fdlg = new FolderBrowserDialog())
            {
                fdlg.ShowNewFolderButton = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    tBOut.Text = fdlg.SelectedPath;
                }
            }
        }
        private short Max16 = 30000;
        private double Rate16 = 1.0;
        

        
        private void btTgt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            {
                lstFile.Clear();
              
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    tbwav.Text = fdlg.SelectedPath;

                }
            }
        }
        //元音列表文件
        string vofile = "";
        string intmode = "";//模板文件对应的interval
        string intfile = "";//数据文件对应的interval
        private void btDo_Click(object sender, EventArgs e)
        {
            if (btDo.Text == "开始处理")
            {
                
                if (Directory.Exists(tbwav.Text) == false)
                {
                    MessageBox.Show("请选待处理wav");
                    tbwav.Focus();
                    return;
                }

                StringBuilder errBuiler = new StringBuilder();
                //if (lBMode.Items.Count == 0)
                //    errBuiler.AppendLine("模板音频不能为空");

              if (String.IsNullOrEmpty(tBOut.Text))
                    errBuiler.AppendLine("请选择输出文件夹");
                if (errBuiler.Length > 0)
                {
                    MessageBox.Show(errBuiler.ToString());
                    return;
                }
                try
                {
                    Max16 = short.Parse(tBClip.Text);
                }
                catch
                {
                    return;
                }
                
                tgtList.Clear();
                
                
                DirectoryInfo dir = new DirectoryInfo(tbwav.Text);
                in_wav_dir = dir.FullName;
                FileInfo[] files = dir.GetFiles("*.wav", SearchOption.AllDirectories);
                foreach (FileInfo fi in files)
                {
                    tgtList.Add(fi.FullName);
                }
                outputPath = tBOut.Text;
                if(Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);
                selectedChannelIn = Convert.ToInt32(nUDChnIn.Value);
                selectedChannelOut = Convert.ToInt32(nUDChnOut.Value);
                db0 = Convert.ToDouble(dbText.Text);


                SetAllEnabled(false);
                btDo.Text = "取消";
                bgWDoWork.RunWorkerAsync();
            }
            else
            {
                bgWDoWork.CancelAsync();
                SetAllEnabled(true);
                btDo.Text = "开始处理";
            }
        }

 
        private void bgWDoWork_DoWork(object sender, DoWorkEventArgs e)
        {
            int srcIndex = 0;
            int tgtIndex = 0;
            List<string> overflowList = new List<string>();

            ReportProgress(srcIndex, tgtIndex, "初始化中");

            if (bgWDoWork.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

             for (tgtIndex = 0; tgtIndex < tgtList.Count; ++tgtIndex)
            {
                ReportProgress(srcIndex, tgtIndex + 1, "调整音量");
                if (bgWDoWork.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }             

                WaveFile inWav = new WaveFile();
                inWav.OpenFile(tgtList[tgtIndex], WaveFormat.WF_NONE);
                int datalength = (int)inWav.GetTotalSample();
                int sampleRate = (int)inWav.GetSamplePerSec();
                short[,] data = null;
                datalength = inWav.GetData(ref data, datalength);

                 // 主要函数  调整幅度值  修改data数据
                 // 处理每个周期内(两次过零点)
                 // 分贝值db=10 * Math.Log10(Math.Pow(V/V0,2))
                 // 幅度值V = sqrt(Math.Pow(10,db/10)) * V0;
                 // 最大幅值V0=32767 
                 // 
                int overflowCnt = AdjustAmpX(ref data, sampleRate);
                

                WaveFile outWav = new WaveFile();
                double len=inWav.GetTotalSample();
                len=len/inWav.GetSamplePerSec();

                String outWavName_temp = "";
                String outWavDir = "";
                outWavName_temp = tgtList[tgtIndex].Replace(in_wav_dir, outputPath);
                outWavDir = Path.GetDirectoryName(outWavName_temp);
                if(!Directory.Exists(outWavDir))
                {
                    Directory.CreateDirectory(outWavDir);
                }

                string outWavName = "";
                //outWavName = outputPath + "\\" + Path.GetFileName(tgtList[tgtIndex]);
                outWavName = outWavName_temp;

                GMSG += "\t文件长=" + len.ToString();


                overflowList.Add(GMSG);
                   
                 // 写wav 
                outWav.OpenFile(outWavName, inWav.WaveFileFormat, false, (uint)sampleRate, (ushort)data.GetLength(0));
                outWav.PutData(data, datalength);
                outWav.FlushFile();
                outWav.CloseFile();
                inWav.DestoryData(ref data);
                inWav.CloseFile();
            }

            if (overflowList.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter(File.Create(outputPath + "\\overflow.log"), Encoding.UTF8))
                {
                    foreach (string line in overflowList)
                        sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();
                }
            }

            ReportProgress(srcIndex, tgtIndex, "完成");
        }

        private void bgWDoWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is string)
            {
                pBProgress.Value = e.ProgressPercentage;
                lbProgress.Text = e.UserState as string;
            }
        }

        private void bgWDoWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) MessageBox.Show("作业被取消");
            else MessageBox.Show("作业完成");
            SetAllEnabled(true);
            btDo.Text = "开始处理";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "合成能量处理工具-音量[v" + FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion.ToString() + "]";
            string vfi = Application.StartupPath + "\\v.txt";
            if (File.Exists(vfi))
            {
                StreamReader sr = new StreamReader(vfi, System.Text.Encoding.UTF8);
                string st = sr.ReadLine();
                sr.Close();
                if (st != null)
                {
                    try { int.Parse(st);
                    tBClip.Text = st;
                    }
                    catch (Exception ex) { }

                }
            }
        }

         
    }
}
