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
                string[] arr = note.Text.Split(new string[]{

                "",

                        }, StringSplitOptions.None);


                foreach (string B in arr)
                {
                    if (B.Contains("\n"))
                        sw.WriteLine("{0}", B
                          .Replace(" ", "")
                          .Replace("\n", "")
                          );
                }

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

                    //sw.WriteLine(B);

                    // 언어물리는 3변수로 정리한다.
                    // 현재 3변수에서 시간은 고려하지 않는다.
                    // 시간은 에너지와 동일한 클래스이다.

                    // 1. 개체 2. 에너지 3. 기호(조사, 접속사, 기호 등)
                    // 나는 집에 가다 = 나+집+가다 = 개체+개체+E

                    // 개체 + 에너지 = 1최소요소
                    // 1최소요소는 절대요소이다.
                    // 최대절대요소는 1개의 띄어쓰기로 한정한다.
                    // 띄어쓰기 갯수는 최대 2개까지로 임시값 한정한다.



                    if (B.EndsWith("학") == true) // 개체
                        sw.WriteLine("{0}", B

                            .Replace("광화학", "개체")
                            );
                    if (B.EndsWith("성") == true) // 개체
                        sw.WriteLine("{0}", B

                            .Replace("반응성", "개체")
                            );

                    if (B.EndsWith("서") == true) // 기호
                        sw.WriteLine("{0}", B

                            .Replace("에서", "서")
                            .Replace("서", " + ")
                            );

                    if (B.EndsWith("다") == true) // 에너지
                        sw.WriteLine("{0}", B

                            .Replace("있다", "있")
                            .Replace("있", "E = 100")

                            .Replace("없다", "없")
                            .Replace("없", "E = 0")
                            );


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