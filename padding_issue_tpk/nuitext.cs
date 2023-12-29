using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUIText
{
    class Program : NUIApplication
    {
        const string TAG = "NUIText";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            GenerateUI(new Size(480, 780));
        }

        public void GenerateUI(Size windowSize)
        {
            Window window = Window.Instance;
            window.WindowSize = windowSize;

            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                    CellPadding = new Size2D(10, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.Black,
            };
            window.Add(view);


            string text = "Hello, World!";

            var labelNoPadding = NewTextLabel(text);
            view.Add(labelNoPadding);

            var label = NewTextLabel(text);
            label.Padding = new Extents(50, 50, 50, 50);
            view.Add(label);


            var fieldNoPadding = NewTextField(text);
            view.Add(fieldNoPadding);

            var field = NewTextField(text);
            field.Padding = new Extents(50, 50, 50, 50);
            view.Add(field);


            var editorNoPadding = NewTextEditor(text);
            view.Add(editorNoPadding);

            var editor = NewTextEditor(text);
            editor.Padding = new Extents(50, 50, 50, 50);
            view.Add(editor);

            var button = NewButton("Get Natural Size");
            view.Add(button);
            button.Clicked += (s, e) =>
            {
                Tizen.Log.Info(TAG, $"label  no pad : {labelNoPadding.NaturalSize.Width}, {labelNoPadding.NaturalSize.Height}, with pad : {label.NaturalSize.Width}, {label.NaturalSize.Height} \n");
                Tizen.Log.Info(TAG, $"field  no pad : {fieldNoPadding.NaturalSize.Width}, {fieldNoPadding.NaturalSize.Height}, with pad : {field.NaturalSize.Width}, {field.NaturalSize.Height} \n");
                Tizen.Log.Info(TAG, $"editor no pad : {editorNoPadding.NaturalSize.Width}, {editorNoPadding.NaturalSize.Height}, with pad : {editor.NaturalSize.Width}, {editor.NaturalSize.Height} \n");
            };
        }

        public TextLabel NewTextLabel(string text)
        {
            var label = new TextLabel
            {
                Text = text,
                MultiLine = true,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
            };
            return label;
        }

        public TextField NewTextField(string text)
        {
            var field = new TextField
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
                MaxLength = 20,
            };
            return field;
        }

        public TextEditor NewTextEditor(string text)
        {
            var editor = new TextEditor
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.WrapContent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                PointSize = 20.0f,
                BackgroundColor = Color.White,
            };
            return editor;
        }

        public Button NewButton(string text)
        {
            var button = new Button(NewButtonStyle())
            {
                Text = text,
                PointSize = 20.0f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                ItemHorizontalAlignment = HorizontalAlignment.Center,
            };
            return button;
        }

        public ButtonStyle NewButtonStyle()
        {
            var style = new ButtonStyle
            {
                CornerRadius = 0.0f,
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(0.25f, 0.75f, 1.0f, 1.0f),
                    Pressed = new Color(0.25f, 0.75f, 1.0f, 0.3f),
                },
                Overlay = new ImageViewStyle()
                {
                    BackgroundColor = new Selector<Color>()
                    {
                        Pressed = new Color(0, 0, 0, 0.1f),
                        Other = new Color(1, 1, 1, 0.1f),
                    },
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Color(0.0f, 0.0f, 0.0f, 1.0f),
                }
            };
            return style;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
