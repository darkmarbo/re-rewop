using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;


namespace MultiPhoneCompare
{
    class CInterval:Object
    {
        List<string> lstHead = new List<string>();
        int laynum = 0;
        List<CLay> lstLays = new List<CLay>();
        public string MSG { get; set; }
        public void Clear()
        {
            lstHead.Clear();
            foreach (CLay lay in lstLays)
            {
                if (lay.items != null)
                {
                    lay.items.Clear();
                    lay.items = null;
                }

            }
            lstLays.Clear();
        }

        public int WritetoFile(string tFile)
        {
            int ret = 0;
            if (lstHead.Count > 0 && lstLays.Count > 0)
            {
                StreamWriter sw=new StreamWriter(tFile,false,System.Text.Encoding.GetEncoding("GB2312"));
                for (int i = 0; i < lstHead.Count; i++)
                    sw.WriteLine(lstHead[i]);
                sw.WriteLine(lstLays.Count.ToString());
                for (int i = 0; i < lstLays.Count; i++)
                {
                    sw.WriteLine(lstLays[i].LayName);
                    sw.WriteLine(lstLays[i].FileName);
                    sw.WriteLine(lstLays[i].start.ToString("0"));
                    sw.WriteLine(lstLays[i].end.ToString());
                    sw.WriteLine(lstLays[i].items.Count.ToString());
                    for (int j = 0; j < lstLays[i].items.Count; j++)
                    {
                        sw.WriteLine(lstLays[i].items[i].start.ToString());
                        sw.WriteLine(lstLays[i].items[i].end.ToString());
                        sw.WriteLine(lstLays[i].items[i].sText);
                    }
                }
                sw.Close();
                    
            }
            return ret;
        }

        public int ReadfromFile(string iFile)
        {
            int ret = 0;
            Clear();
            if (File.Exists(iFile))
            {
                StreamReader sr=null;
                int n = 0;
                try
                {
                    sr = new StreamReader(iFile, System.Text.Encoding.GetEncoding("GB2312"));
                    while (n < 6 && sr.Peek() > 0)
                    {
                        string str = sr.ReadLine();
                        lstHead.Add(str);
                        n++;
                    }
                    if (sr.Peek() > 0)
                    {
                        string tmp = sr.ReadLine();
                        laynum = int.Parse(tmp);
                    }
                    for (int i = 0; i < laynum; i++)
                    {
                        CLay lay= new CLay();
                        string str = sr.ReadLine();
                        lay.LayName = str;
                        str = sr.ReadLine();
                        lay.FileName = str;
                        str = sr.ReadLine();
                        lay.start = double.Parse(str);
                        str = sr.ReadLine();
                        lay.end = double.Parse(str);
                        str = sr.ReadLine();
                        lay.ItemNum = int.Parse(str);

                        if (lay.items == null)
                            lay.items = new List<CItem>();
                        n = 0;
                      
                        string srt = "", ed = "", tx = "";

                        while(lay.items.Count< lay.ItemNum)
                        {
                            str = sr.ReadLine();
                            int dflag=0;
                            try
                            {
                                double.Parse(str);
                                dflag=1;
                            }
                            catch
                            {}
                            if ((n == 3 && dflag == 1)||(str=="\"IntervalTier\"")||str==null)
                            {
                                CItem item = new CItem();
                                item.end = double.Parse(ed);
                                item.start = double.Parse(srt);
                                item.sText = tx;
                                lay.items.Add(item);
                                tx = ""; srt = ""; ed = "";
                                n = 0;
                                if (lay.items.Count >= lay.ItemNum)
                                {
                                    lstLays.Add(lay);
                                    break;
                                }
                              
                            }

                            if (n==0&&dflag==1)
                            {
                                tx = "";
                                srt = str;
                                n++;
                                continue;
                            }
                            if (n == 1 && dflag == 1)
                            {
                                tx = "";
                                ed = str;
                                n++;
                                continue;
                            }
                            if (n == 2 && dflag == 0)
                            {
                                tx = str;
                                n++;
                                continue;
                            }
                            if (n == 3 && dflag == 0)
                            {
                                tx += str;
                                continue;
                                
                            }
                        }
                    }
                }
                catch
                {
                    MSG += "加载错误";
 
                }
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
        /// <summary>
        /// 找到相应位置
        /// </summary>
        /// <param name="alpy"></param>
        /// <param name="pos"></param>
        /// <param name="dstart"></param>
        /// <param name="dend"></param>
        /// <returns></returns>
        public int FindWordPosition(List<string> alpy,int layNo, int pos,ref double dstart,ref double dend)
        {

            int idx = 0;
            alpy.Remove("");
            for (int i = 0; i < pos; i++)
            {
                string py = alpy[i];
                string[] pys = py.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    CItem citem = lstLays[layNo].items[idx];
                    string ichar = citem.sText;
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(0, ichar.Length - 1);
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(1, ichar.Length - 1);
                    while (ichar == "sil" || ichar == "sp")
                    {
                        idx++;

                        citem = lstLays[layNo].items[idx];
                        ichar = citem.sText;
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(0, ichar.Length - 1);
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(1, ichar.Length - 1);

                    }
                    ichar = ichar.Replace("-1", "");
                    ichar = ichar.Replace("*", "");
                    for (int j = 0; j < pys.Length; j++)
                    {
                        if (pys[j] == ichar)
                        {
                            idx++;

                            if (idx < lstLays[layNo].items.Count)
                            {
                                citem = lstLays[layNo].items[idx];
                                ichar = citem.sText;
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(0, ichar.Length - 1);
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(1, ichar.Length - 1);
                                //    ichar = alit[idx].ToString();
                                ichar = ichar.Replace("-1", "");
                                ichar = ichar.Replace("*", "");

                                if (ichar == "sp" && j < pys.Length - 1)
                                {

                                    idx++;
                                    citem = lstLays[layNo].items[idx];
                                    ichar = citem.sText;
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(0, ichar.Length - 1);
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(1, ichar.Length - 1);
                                    ichar = ichar.Replace("-1", "");
                                    ichar = ichar.Replace("*", "");

                                }
                            }
                            else
                            {
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            //.Add(alem[idx].ToString() + "\t" + ichar + "\t" + pys[j] + " 不一致");
                            // return al;
                        }
                    }
                }
                catch
                {
                    //al.Add("可能存在拼音和文本个数不一致");
                    //return al;
                }



            }
            {
                string py = alpy[pos];
                string[] pys = py.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    CItem citem = lstLays[layNo].items[idx];
                    string ichar = citem.sText;
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(0, ichar.Length - 1);
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(1, ichar.Length - 1);
                    while (ichar == "sil" || ichar == "sp")
                    {
                        idx++;

                        citem = lstLays[layNo].items[idx];
                        ichar = citem.sText;
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(0, ichar.Length - 1);
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(1, ichar.Length - 1);

                    }
                    ichar = ichar.Replace("-1", "");
                    ichar = ichar.Replace("*", "");
                    for (int j = 0; j < pys.Length; j++)
                    {

                        if (pys[j] == ichar)
                        {
                            idx++;

                            if (idx < lstLays[layNo].items.Count)
                            {
                                citem = lstLays[layNo].items[idx];
                                if (j == 0)

                                    dstart = citem.start;
                                dend = citem.end;
                                ichar = citem.sText;
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(0, ichar.Length - 1);
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(1, ichar.Length - 1);
                                //    ichar = alit[idx].ToString();
                                ichar = ichar.Replace("-1", "");
                                ichar = ichar.Replace("*", "");

                                if (ichar == "sp" && j < pys.Length - 1)
                                {

                                    idx++;
                                    citem = lstLays[layNo].items[idx];
                                    ichar = citem.sText;
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(0, ichar.Length - 1);
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(1, ichar.Length - 1);
                                    ichar = ichar.Replace("-1", "");
                                    ichar = ichar.Replace("*", "");

                                }
                            }
                            else
                            {
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            //.Add(alem[idx].ToString() + "\t" + ichar + "\t" + pys[j] + " 不一致");
                            // return al;
                        }
                    }
                }
                catch
                {
                    //al.Add("可能存在拼音和文本个数不一致");
                    //return al;
                }

            }
            //return al;
            return idx;
        }

        /// <summary>
        /// 找到相应位置
        /// </summary>
        /// <param name="alpy"></param>
        /// <param name="pos"></param>
        /// <param name="dstart"></param>
        /// <param name="dend"></param>
        /// <returns></returns>
        public int FindWordPosition(ArrayList alpy, int layNo, int pos, ref double dstart, ref double dend)
        {

            int idx = 0;
            alpy.Remove("");
            for (int i = 0; i < pos; i++)
            {
                string py = alpy[i].ToString();
                string[] pys = py.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    CItem citem = lstLays[layNo].items[idx];
                    string ichar = citem.sText;
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(0, ichar.Length - 1);
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(1, ichar.Length - 1);
                    while (ichar == "sil" || ichar == "sp")
                    {
                        idx++;

                        citem = lstLays[layNo].items[idx];
                        ichar = citem.sText;
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(0, ichar.Length - 1);
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(1, ichar.Length - 1);

                    }
                    ichar = ichar.Replace("-1", "");
                    ichar = ichar.Replace("*", "");
                    for (int j = 0; j < pys.Length; j++)
                    {
                        if (pys[j] == ichar)
                        {
                            idx++;

                            if (idx < lstLays[layNo].items.Count)
                            {
                                citem = lstLays[layNo].items[idx];
                                ichar = citem.sText;
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(0, ichar.Length - 1);
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(1, ichar.Length - 1);
                                //    ichar = alit[idx].ToString();
                                ichar = ichar.Replace("-1", "");
                                ichar = ichar.Replace("*", "");

                                if (ichar == "sp" && j < pys.Length - 1)
                                {

                                    idx++;
                                    citem = lstLays[layNo].items[idx];
                                    ichar = citem.sText;
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(0, ichar.Length - 1);
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(1, ichar.Length - 1);
                                    ichar = ichar.Replace("-1", "");
                                    ichar = ichar.Replace("*", "");

                                }
                            }
                            else
                            {
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            //.Add(alem[idx].ToString() + "\t" + ichar + "\t" + pys[j] + " 不一致");
                            // return al;
                        }
                    }
                }
                catch
                {
                    //al.Add("可能存在拼音和文本个数不一致");
                    //return al;
                }



            }
            {
                string py = alpy[pos].ToString();
                string[] pys = py.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    CItem citem = lstLays[layNo].items[idx];
                    string ichar = citem.sText;
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(0, ichar.Length - 1);
                    if (ichar.Length > 0)
                        ichar = ichar.Substring(1, ichar.Length - 1);
                    while (ichar == "sil" || ichar == "sp")
                    {
                        idx++;

                        citem = lstLays[layNo].items[idx];
                        ichar = citem.sText;
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(0, ichar.Length - 1);
                        if (ichar.Length > 0)
                            ichar = ichar.Substring(1, ichar.Length - 1);

                    }
                    ichar = ichar.Replace("-1", "");
                    ichar = ichar.Replace("*", "");
                    for (int j = 0; j < pys.Length; j++)
                    {

                        if (pys[j] == ichar)
                        {
                            idx++;

                            if (idx < lstLays[layNo].items.Count)
                            {
                                citem = lstLays[layNo].items[idx];
                                if (j == 0)

                                    dstart = citem.start;
                                dend = citem.end;
                                ichar = citem.sText;
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(0, ichar.Length - 1);
                                if (ichar.Length > 0)
                                    ichar = ichar.Substring(1, ichar.Length - 1);
                                //    ichar = alit[idx].ToString();
                                ichar = ichar.Replace("-1", "");
                                ichar = ichar.Replace("*", "");

                                if (ichar == "sp" && j < pys.Length - 1)
                                {

                                    idx++;
                                    citem = lstLays[layNo].items[idx];
                                    ichar = citem.sText;
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(0, ichar.Length - 1);
                                    if (ichar.Length > 0)
                                        ichar = ichar.Substring(1, ichar.Length - 1);
                                    ichar = ichar.Replace("-1", "");
                                    ichar = ichar.Replace("*", "");

                                }
                            }
                            else
                            {
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            //.Add(alem[idx].ToString() + "\t" + ichar + "\t" + pys[j] + " 不一致");
                            // return al;
                        }
                    }
                }
                catch
                {
                    //al.Add("可能存在拼音和文本个数不一致");
                    //return al;
                }

            }
            //return al;
            return idx;
        }

         /// <summary>
        /// 找到相应位置
        /// </summary>
        /// <param name="alpy"></param>
        /// <param name="pos"></param>
        /// <param name="dstart"></param>
        /// <param name="dend"></param>
        /// <returns></returns>
        public void FindWordPositionX(ArrayList alpy, int layNo, int pos, ref double dstart, ref double dend)
        {
            int num = 0;
            int start = 0, end = 0;
            for (int i = 0; i <= pos; i++)
            {
                string st = alpy[i].ToString();
                string[] sts = st.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
                if(i==pos)
                  start = num + 1;

                num += sts.Length;
                if (i == pos)
                    end = num;
            }

            int idx = 0;
            for (int i = 0; i < lstLays[0].items.Count; i++)
            {
                if (lstLays[0].items[i].sText != "sp" && lstLays[0].items[i].sText != "sil")
                    idx++;
                if (idx == start && idx < lstLays[0].items.Count)
                    dstart = lstLays[0].items[idx].start;
                if (idx == end && idx < lstLays[0].items.Count)
                {
                    dend = lstLays[0].items[idx].end;
                    break;
                }
                        
 
            }
            
            


        }

    }
    /// <summary>
    /// 一个interval
    /// </summary>
    public struct CItem
    {
        public double start; 
        public double end; 
        public string sText; 
        public string Text;
    }
    public class CLay{
        public int layid;
        public string LayName,FileName;
        public double start,end;
        public int ItemNum;
        public List<CItem> items=null;
        
    }
}
