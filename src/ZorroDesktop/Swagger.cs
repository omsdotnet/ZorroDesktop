using System;
using System.Reflection;
using System.Windows.Forms;

namespace ZorroDesktop
{
    public class swagger
    {
        public static Form GetForm<T>(T appPresenter) where T : class
        {
            var ret = new Form()
            {
                AutoScroll = true
            };

            MethodInfo[] info = typeof(T).GetMethods(BindingFlags.Instance
                      | BindingFlags.Static
                      | BindingFlags.Public
                      | BindingFlags.InvokeMethod
                      | BindingFlags.DeclaredOnly);

            Array.Reverse(info);

            for (int i = 0; i < info.Length; i++)
            {
                var method = info[i];
                var methodParameters = method.GetParameters();

                if (methodParameters.Length == 0)
                {
                    var resultPanel = new Panel()
                    {
                        Dock = DockStyle.Top,
                        Height = 24
                    };
                    var resultText = new TextBox() { Dock = DockStyle.Fill };
                    if (method.ReturnType != typeof(void))
                    {
                        resultPanel.Controls.Add(resultText);
                    }
                    ret.Controls.Add(resultPanel);

                    var buttonPanel = new Panel()
                    {
                        Dock = DockStyle.Top,
                        Height = 24
                    };
                    var button = new Button()
                    {
                        Text = @"Try to execute",
                        Width = 100
                    };
                    button.Click += (s, e) =>
                    {
                        var result = method.Invoke(appPresenter, null);

                        resultText.Text = result == null ? @"<NULL>" : result.ToString();
                    };

                    buttonPanel.Controls.Add(button);
                    ret.Controls.Add(buttonPanel);

                    var namePanel = new Panel()
                    {
                        Dock = DockStyle.Top,
                        Height = 24
                    };
                    namePanel.Controls.Add(new Label() { Text = method.Name, Dock = DockStyle.Fill });
                    ret.Controls.Add(namePanel);
                }
            }

            var classNamePanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 24
            };
            classNamePanel.Controls.Add(new Label() { Text = typeof(T).FullName, Dock = DockStyle.Fill });
            ret.Controls.Add(classNamePanel);

            return ret;
        }
    }
}