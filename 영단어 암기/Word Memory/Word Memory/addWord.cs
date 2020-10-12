using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Word_Memory
{
    public partial class addWord : Form
    {
        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;
        Thread searchThread;
        public addWord()
        {
            InitializeComponent();
            tb_word.Select();
            //크롬실행
            try
            {
                _driverService = ChromeDriverService.CreateDefaultService();
                _driverService.HideCommandPromptWindow = true;

                _options = new ChromeOptions();
                _options.AddArgument("disable-gpu");
                _driver = new ChromeDriver(_driverService, _options);

                _driver.Navigate().GoToUrl("https://en.dict.naver.com/#/main");
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
                searchThread.Abort();
            }

        }

       
        /// <summary>
        /// 네이버사전 이용해서 뜻가져오기
        /// </summary>
        void SearchWord()
        {
            //검색
            try
            {
                _driver.Navigate().GoToUrl("https://en.dict.naver.com/#/main");
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                var shearchWindow = _driver.FindElementById("ac_input");
                shearchWindow.SendKeys(tb_word.Text);

                var shearchButton = _driver.FindElementByXPath("//*[@id='searchArea']/div/button");
                shearchButton.Click();

                var fistWord = _driver.FindElementByXPath("//*[@id='searchPage_entry']/div/div[1]/div[1]/a");
                fistWord.Click();

                //뜻이 없으면 오류 표시하기
                //품사 구별하기
                //최대 5개 까지 표시
                tb_mean.Clear();
                int i = 0;
                foreach(var means in _driver.FindElementsByClassName("mean"))
                {
                    tb_mean.Text += means.Text + "\r\n";
                    i++;
                    if(i == 5)
                    {
                        break;
                    }
                }
                
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
            finally
            {
                searchThread.Abort();
            }
        }


        private void addWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            _driver.Quit();
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            searchThread = new Thread(new ThreadStart(SearchWord));
            searchThread.Start();
        }

        private void addWord_Load(object sender, EventArgs e)
        {
            rbtn_Dic.Checked = true;
        }

        private void tb_word_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                e.Handled = true;
                btn_search_Click(sender, e);

            }
        }
    }
}
