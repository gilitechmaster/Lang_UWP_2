using System;
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
        async void OnSaveButtonClicked(object sender, EventArgs e) //저장버튼 누르면
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
        }

        async void OnCalc1ButtonClicked(object sender, EventArgs e) // 조합버튼
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

                //AAAAAAAAAA

                string[] arr = note.Text.Split(new string[]{

                "." // .dot을 없애고 단나눔
                
                // 왜 split으로 조합하고있는지?
                // format 등 다른 sting 클래스에 메서드를 찾자.
                // 조합 = 자석착으로 문장조합
                // 나는 집에 가다 -> 나 집 가 (분해) -> 나집가 (조합)

                        }, StringSplitOptions.None);


                foreach (string B in arr)
                {

                    //if (B.Contains(".")
                    //)
                    //sw.WriteLine("{0}", B
                    //.Replace(".", "")
                    //.Replace("\n", "")
                    //);

                    //split로 단나눔된 결과에서 contains로 조건조회 후 replace
                    if (B.Contains("\n")) // 자석착으로 .\nA -> .A
                        sw.WriteLine("{0}", B
                          .Replace(" ", "") // 자석착은 실패이므로 
                          .Replace("\n", "") //AAAAAAAAAA 부터 AAAAAAAAAA 까지 재작업해야함
                          );

                }  //AAAAAAAAAA

                sw.Close();

            }


            await Navigation.PopAsync();
        }

        async void OnCalc2ButtonClicked(object sender, EventArgs e) // 분해버튼
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

                    ". ",  // 순차처리하므로 ". "를 앞에해두어야 한다.
                    ".",
                    ", ",
                    ",",
                    "? ",
                    "?",
                    "! ",
                    "!",
                    "·", // 법률문서에 사용되는 기호
                    " "

                        }, StringSplitOptions.None);

                foreach (string B in arr)
                {
                    //sw.WriteLine("                                      " + B); // 원본을 출력한다.
                    sw.WriteLine(B + "."); // 원본+자석착

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
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e) // 삭제버튼
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();
        }
    }
}
