using Lang_UWP_2;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace Lang_UWP_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename)) //문자열이 널인지 공백인지 확인한다.
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();
        }//저장버튼 누르면

        async void OnCalc1ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }

            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);
                string[] arr = note.Text.Split(new string[]{

                "",

                        }, StringSplitOptions.None);


                foreach (string B in arr)
                {

                    if (B.Contains("\n")  // replace로 2차처리
                        )
                        sw.WriteLine("{0}", B
                          .Replace("\n", "")
                          );

                }

                sw.Close();

            }


            await Navigation.PopAsync();
        }
        //조합버튼 누르면
        //웹에서 문서를 수집하면, 어수선한 글이 많아서
        //조합을 먼저한 이후에 분해한다.

        async void OnCalc2ButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }

            else
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(note.Filename, note.Text);
                StreamWriter sw = new StreamWriter(filename, true);
                string[] arr = note.Text.Split(new string[]{

                    ". ",  //순차처리하므로 ". "를 앞에해두어야 한다.
                    ".",
                    ", ",
                    ",",
                    "? ",
                    "?",
                    "! ",
                    "!",
                    " "

                        }, StringSplitOptions.None);
                //int Key = 1;

                foreach (string B in arr)
                {
                    //sw.WriteLine(Key++ + ") " + B); //key값은 삭제하도록 한다.
                    sw.WriteLine(B);

                    if (B.EndsWith("야") == true)
                        sw.WriteLine("{0}", B
                            .Replace("하여야", "\n" + "하여야")
                            );
                    //하여야 = n% = 불확정, 시간불확정
                    //100% = 확정 = dry = 진리
                    
                }
                sw.Close();

            }

            await Navigation.PopAsync();
        }//분해버튼 누르면

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();
        }//삭제버튼 누르면
    }
}
