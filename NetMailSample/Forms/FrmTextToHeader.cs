using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Security.Policy;
using NetMailSample.Common;

namespace NetMailSample.Forms
{
    public partial class FrmTextToHeader : Form
    {
     
        public Hashtable HeaderTable = new Hashtable();
        int HeaderNumber = 0;
        public FrmTextToHeader()
        {
            InitializeComponent();
            //adding helper to get right click integrated with rich text box.
            rchBox.EnableContextMenu();
        }
        
        //
        // This button will try to add each line as header to the email
        //

        private void BtnProcessAsHeader_Click(object sender, EventArgs e)
        {
            
            var textDoc = rchBox.Text;

            string headerName = null;
            string headerValue = null;
            foreach (var line in textDoc.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {

                string[] header = CheckForLoad(line);

                if ((line.IndexOf(": ")) != -1)
                {
                    if ((header[0] != null) & (headerName != null))
                    {
                        FillTheTable(headerName, headerValue);
                        headerName = null;
                        headerValue = null;
                    }

                    headerName = header[0];
                    headerValue = header[1];
                }
                else
                {
                    //if single line exist
                    headerValue = headerValue + header[0];
                }

            }
            // below FillTheTable call added for the catching last item in the test document, othervise we will lost it
            FillTheTable(headerName, headerValue);
            
            FrmMain f = this.Owner as FrmMain;
            // clear exiting values from Main Form gridview
            f.dgGridHeaders.Rows.Clear();

            var dictionary = HeaderTable.Cast<DictionaryEntry>().ToDictionary(kvp => (int)kvp.Key, kvp => (string)kvp.Value);
            var sorted = new SortedDictionary<int, string>(dictionary);
        
            foreach ( KeyValuePair<int,string>k in sorted)
            {
                string[] header = CheckForLoad(k.Value.ToString());
                object[] headerK = CheckForLoad(k.Value.ToString());
                f.dgGridHeaders.Rows.Add(header);
            }
                Close();

            
        }
        string[] CheckForLoad(string line)
        {
            string[]strDelimiter = { ": " } ;// based on RFC documentation header should be ':' and ' ' 
            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] str = line.Split(strDelimiter, 2,StringSplitOptions.None);
                return str;
            }
            else
            {
                return null;
            }

        }

        void FillTheTable(string header0,string header1)
        {
                       
            HeaderTable.Add(HeaderNumber,header0 + ": "+header1);
            HeaderNumber++;

        }

    }

 }
