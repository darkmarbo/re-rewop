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
            btSrc.Enabled = value;
            btTgt.Enabled = value;
            btClear.Enabled = value;
            nUDChnIn.Enabled = value;
            nUDChnOut.Enabled = value;
            nUDIgnore.Enabled = value;
            nUDFrameTime.Enabled = value;
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
            int channelIndex = selectedChannelIn;
            int flen = (int)(SampleRate * frametime);              //帧长点数

            int num = list_item.Count;  // 所有元音总数
            //PowerZeroVAD(tdata, tdata.Length, stt * 2, stt, ref begin, ref end, ref num);
 
            GC.Collect();
            double temp = 0;
            if (channelIndex >= data.GetLength(0)) channelIndex = data.GetLength(0) - 1;
            if (channelIndex < 0) channelIndex = 0;

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
                    temp = (double)data[channelIndex, j] / 32768;
                    fAmpMean += temp * temp;                              //累加
                }
            }
            return fAmpMean / sumf;                                        //平均每个采样点能量
        }
 
        string GMSG = "";
        int AdjustAmpX(ref short[,] data, int SampleRate, double targetAmp, List<item> list_item)
        {
            GMSG = "";
            double overflowCnt = 0;
            double rate = 1.0, tmprate = 1.0;
            //double th = 0.000001;
            double th = 0.000001;
            
            // 计算当前语音的 平均能量值 or 最大幅度
            //double myAmp = ExtractAmpFeats_Max(data, SampleRate);
            double myAmp = ExtractAmpFeats_int(data, SampleRate,list_item);
            
            if (Math.Abs(targetAmp - myAmp) < th){ return 0; }
            
            // 计算 系数
            //double factor = targetAmp / myAmp;
            double factor = Math.Sqrt(targetAmp / myAmp);

            int channelIndex = selectedChannelOut;
            if (channelIndex >= data.GetLength(0))
            {
                channelIndex = data.GetLength(0) - 1;
            }
            if (channelIndex < 0)
            {
                channelIndex = 0;
            } 
            int cnt = 1;
            int flag=1;
            while (flag == 1)
            {
                flag = 0;
                for (int i = 0; i < data.GetLength(1); ++i)
                {
                    double value = (double)data[channelIndex, i];
                    value *= factor;
                    if ((Math.Abs(value)) >= Max16)
                    {
                        cnt++;
                        flag = 1;
                    }
                }
                if (flag == 1)
                {
                    if (GMSG == "")
                        GMSG = "\t截幅调整"+factor.ToString() ;
                    factor -= 0.01;
                }
            }

            for (int i = 0; i < data.GetLength(1); ++i)
            {
                double value = (double)data[channelIndex, i];
                if (Math.Abs(value) > 30)
                {
                    int n = 100;
                    n++;
                }
                value *= factor;
                data[channelIndex, i] = (short)Math.Round(value);
            }
            GMSG += "\t倍数=" + factor.ToString("N3") + "\t原能量=" + myAmp.ToString("N5");
            
            return cnt;
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
        
        private void btSrc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog odlg = new OpenFileDialog())
            {
                odlg.Filter = "WAV Files|*.wav|All Files|*.*";
                odlg.Multiselect = true;
                if (odlg.ShowDialog() == DialogResult.OK)
                {
                    lBMode.SuspendLayout();
                    lBMode.Items.Clear();
                    for (int i = 0; i < odlg.FileNames.Length; i++)
                        lBMode.Items.Add(odlg.FileNames[i]);
                    lBMode.ResumeLayout();
                }
            }
        }

        
        private void btTgt_Click(object sender, EventArgs e)
        {
            /*
            using (OpenFileDialog odlg = new OpenFileDialog())
            {
                lstFile.Clear();
                odlg.Filter = "WAV Files|*.wav|All Files|*.*";
                odlg.Multiselect = true;
                if (odlg.ShowDialog() == DialogResult.OK)
                {
                    lBFile.SuspendLayout();
                    lBFile.Items.Clear();
                    foreach (string str in odlg.FileNames)
                    {
                        if (lBFile.Items.Count < 100)
                            lBFile.Items.Add(str);
                        lstFile.Add(str);
                    }
                    lBFile.ResumeLayout();
                }
            }*/

            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            {
                lstFile.Clear();
              
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    tbwav.Text = fdlg.SelectedPath;
/*                    lBFile.SuspendLayout();

                    DirectoryInfo dir = new DirectoryInfo(fdlg.SelectedPath);
                    in_wav_dir = dir.FullName;
                    FileInfo[] files = dir.GetFiles("*.wav", SearchOption.AllDirectories);
                    foreach (FileInfo fi in files)
                    {
  //                      if (lBFile.Items.Count < 100)
    //                        lBFile.Items.Add(fi.FullName);
                        lstFile.Add(fi.FullName);
                    }
                    lBFile.ResumeLayout();
 * */
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
                if (Directory.Exists(tbmodeint.Text) == false)
                {
                    MessageBox.Show("请选模板interval");
                    btnmode.Focus();
                    return;
                }
                if (Directory.Exists(tbwav.Text) == false)
                {
                    MessageBox.Show("请选待处理wav");
                    tbwav.Focus();
                    return;
                }
                if (Directory.Exists(tbdataint.Text) == false)
                {
                    MessageBox.Show("请选模板interval");
                    btdataint.Focus();
                    return;

                }
                intmode = tbmodeint.Text;
                intfile = tbdataint.Text;
                if (File.Exists(tbvo.Text) == false)
                {
                    MessageBox.Show("请选择元音列表");
                    return;
                }
                vofile = tbvo.Text;
                StringBuilder errBuiler = new StringBuilder();
                if (lBMode.Items.Count == 0)
                    errBuiler.AppendLine("模板音频不能为空");

              if (String.IsNullOrEmpty(tBOut.Text))
                    errBuiler.AppendLine("为选择输出文件夹");
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
                srcList.Clear();
                tgtList.Clear();
                foreach (string src in lBMode.Items) srcList.Add(src);
                
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
                ignoreSample = Convert.ToInt32(nUDIgnore.Value);
                frametime = Convert.ToDouble(nUDFrameTime.Value);

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

        private void btClear_Click(object sender, EventArgs e)
        {
            lBFile.Items.Clear();
            lBMode.Items.Clear();
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



            // 读取 元音 list 
            String yyFile = vofile;//"D:\\能量调整\\王建峰\\调整声音能量测试数据\\20160426\\三星100句\\美语元音音素.txt";
            List<String> list_yy = new List<string>();
            read_yuanyin(yyFile, ref list_yy);
            //for (int i = 0; i < list_yy.Count;i++ )
            //{
              //overflowList.Add(String.Format("{0}",list_yy[i]));
            //}

            
            // 计算模板数据的平均能量或者平均幅度 
            overflowList.Add(String.Format("======\t标准语音的能量值\t===="));
            double targetAmp = 0.0;
            for (srcIndex = 0; srcIndex < srcList.Count; ++srcIndex)
            {
                ReportProgress(srcIndex + 1, tgtIndex, "计算系数");
                if (bgWDoWork.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                String dir_inter = intmode + "\\";
                String inter_name = Path.GetFileName(srcList[srcIndex]).Replace(".wav", ".interval");
                dir_inter = dir_inter + inter_name;
                //overflowList.Add(String.Format("interval_name:\t{0}\t\n", dir_inter));
                List<item> list_item = new List<item>();
                int ret = readInt(dir_inter, ref list_item,list_yy);
                //for (int i = 0; i < list_item.Count;i++ )
                //{
                  //  overflowList.Add(String.Format("{0}\t{1}\t{2}\n",
                    //    list_item[i].st,list_item[i].end,list_item[i].text));
                //}


                WaveFile inWav = new WaveFile();
                inWav.OpenFile(srcList[srcIndex], WaveFormat.WF_NONE);
                int datalength = (int)inWav.GetTotalSample();
                int sampleRate = (int)inWav.GetSamplePerSec();
                short[,] data = null;
                datalength = inWav.GetData(ref data, datalength);

                stt =(int)( WINDOW_SLIP * inWav.GetSamplePerSec());
   
                double amp_temp = ExtractAmpFeats_int(data, sampleRate, list_item);

                overflowList.Add(String.Format("{0}\t{1:N5}",
                    Path.GetFileName(srcList[srcIndex]), amp_temp));
                targetAmp += amp_temp;

                inWav.DestoryData(ref data);
                inWav.CloseFile();
            }

            targetAmp /= (double)srcList.Count;
            overflowList.Add( String.Format("标准平均能量值:{0:N5}", targetAmp) );

            bgWDoWork.ReportProgress(0, targetAmp);
            
            
            // 列出所有interval 文件的全路径
            List<String> list_int = new List<string>();
            DirectoryInfo dir_int = new DirectoryInfo(intfile); // interval所在目录名字
            FileInfo[] files = dir_int.GetFiles("*.interval", SearchOption.AllDirectories);
            foreach (FileInfo fi in files)
            {
                list_int.Add(fi.FullName);
            }

            // 调整 输入数据的 data 
            overflowList.Add(String.Format("======\t转换后的语音的能量值\t===="));
            for (tgtIndex = 0; tgtIndex < tgtList.Count; ++tgtIndex)
            {
                ReportProgress(srcIndex, tgtIndex + 1, "调整音量");
                if (bgWDoWork.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }             

                
                String dir_inter = "";
                String inter_name = Path.GetFileName(tgtList[tgtIndex]).Replace(".wav", ".interval");
                for (int ii = 0; ii < list_int.Count; ii++ )
                {
                    if(inter_name.Equals(Path.GetFileName(list_int[ii])))
                    {
                        dir_inter = list_int[ii];
                        break;
                    }
                }
                
                //overflowList.Add(String.Format("!!!!!!!!!!!{0}!!!!!!!!!!!\n", dir_inter));
                List<item> list_item = new List<item>();
                
                int ret = readInt(dir_inter, ref list_item, list_yy);
                if (ret != 0)
                {
                    continue;
                }
                //for (int i = 0; i < list_item.Count; i++)
                //{
                //  overflowList.Add(String.Format("{0}\t{1}\t{2}\n",
                //    list_item[i].st, list_item[i].end, list_item[i].text));
                //}

                WaveFile inWav = new WaveFile();
                inWav.OpenFile(tgtList[tgtIndex], WaveFormat.WF_NONE);
                int datalength = (int)inWav.GetTotalSample();
                int sampleRate = (int)inWav.GetSamplePerSec();
                short[,] data = null;
                datalength = inWav.GetData(ref data, datalength);

                int overflowCnt = AdjustAmpX(ref data, sampleRate, targetAmp, list_item);
                
                // 测试 输出转换后的data数据的能量值 
                double amp_temp = ExtractAmpFeats_int(data, sampleRate,list_item);
                GMSG += "\t后能量=" + amp_temp.ToString("N5");
                //overflowList.Add(String.Format("{0}\t{1}",
                  //  Path.GetFileName(tgtList[tgtIndex]), amp_temp));

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

                if (overflowCnt == 1)
                {
                    overflowList.Add(String.Format("{0}\t调整={1}" + GMSG, 
                        Path.GetFileName(tgtList[tgtIndex]),overflowCnt));
                    //overflowList.Add(String.Format("调整{0}:{1}" + GMSG, Path.GetFileName(tgtList[tgtIndex]), overflowCnt));
                }
                else if (overflowCnt > 1)
                {
                    overflowList.Add(String.Format("{0}\t截幅={1}" + GMSG, 
                        Path.GetFileName(tgtList[tgtIndex]),overflowCnt));
                }
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
            if (e.UserState is double)
            {
                tBAvg.Text = ((double)e.UserState).ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();
            if (odlg.ShowDialog() == DialogResult.OK)
                tbvo.Text = odlg.FileName;

        }

        private void btnmode_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
                tbmodeint.Text = fdlg.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
                tbdataint.Text = fdlg.SelectedPath;

        }
       
    }
}
