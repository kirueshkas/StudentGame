using System;
using StudentGame.Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StudentGame.Game
{
    class EditorScene : Engine.Scene
    {

        Button backButton = Interface.CreateButton(100, 50, 10, 10, "Back", "back");
        Sprite2D secondHand = new Sprite2D(new Point(0, 0), "secondHand", Resource.character_editor);
        Button backHelmetButton = Interface.CreateButton(250, 50, 200, 200, "BackHelmet",  "backHelmet");
        Button nextHelmetButton = Interface.CreateButton(250, 50, 1500, 200, "NextHelmet", "nextHelmet");
        Button backBodyButton = Interface.CreateButton(250, 50, 200, 400, "BackBody", "backBody");
        Button nextBudyButton = Interface.CreateButton(250, 50, 1500, 400, "NextBody", "nextBody");
        Button backLegButton = Interface.CreateButton(250, 50, 200, 600, "BackLeg", "backLeg");
        Button nextLegButton = Interface.CreateButton(250, 50, 1500, 600, "NextLeg", "nextLeg");
        Button changeSexButton = Interface.CreateButton(250, 50, 830, 10, "ChangeSex",  "ChangeSex");
        Sprite2D editorCharacter = new Sprite2D(new Point(870, 550), "Character", Resource.ManCharacter);
        static string characterSex = "woman";
        // Button BackSceneButton = Interface.CreateButton(100, 100, 10, 10, "Back", Resource.button_new, "Back");

        //Clothes
        static Sprite2D body1 = new Sprite2D(new Point(870, 700), "body1", Resource.Body1);
        static Sprite2D body2 = new Sprite2D(new Point(870, 700), "body2", Resource.Body2);
        static Sprite2D body3 = new Sprite2D(new Point(870, 700), "body3", Resource.Body3);
        static Sprite2D body4 = new Sprite2D(new Point(870, 700), "body4", Resource.Body4);
        static Sprite2D body5 = new Sprite2D(new Point(870, 700), "body5", Resource.Body5);

        static Sprite2D leg1 = new Sprite2D(new Point(900, 840), "leg1", Resource.Leg1);
        static Sprite2D leg2 = new Sprite2D(new Point(900, 840), "leg2", Resource.Leg2);
        static Sprite2D leg3 = new Sprite2D(new Point(900, 840), "leg3", Resource.Leg3);
        static Sprite2D leg4 = new Sprite2D(new Point(900, 840), "leg4", Resource.Leg4);
        static Sprite2D leg5 = new Sprite2D(new Point(900, 840), "leg5", Resource.Leg5);

        Sprite2D[] BodyClothes = new Sprite2D[]
        {
            body1,
            body2,
            body3,
            body4,
            body5
        };
        int bodyIndex = 0;

        Sprite2D[] LegClothes = new Sprite2D[]
        {
            leg1,
            leg2,
            leg3,
            leg4,
            leg5
        };
        int legIndex = 0;


        public override void OnLoad()
        {
            CreateEdtior();
        }

        public override void OnUpdate()
        {
        }


        public void CreateEdtior()
        {
            this.RegisterButton(backButton);
            backButton.Click += EditorBackButton_Click;
            this.RegisterSprite(secondHand);
            this.RegisterButton(backHelmetButton);
            this.RegisterButton(nextHelmetButton);
            this.RegisterButton(backBodyButton);
            backBodyButton.Click += EditorButtons_Click;
            this.RegisterButton(nextBudyButton);
            nextBudyButton.Click += EditorButtons_Click;
            this.RegisterButton(backLegButton);
            backLegButton.Click += EditorButtons_Click;
            this.RegisterButton(nextLegButton);
            nextLegButton.Click += EditorButtons_Click;
            this.RegisterButton(changeSexButton);
            changeSexButton.Click += EditorButtons_Click;
            this.RegisterSprite(editorCharacter);
            this.RegisterSprite(BodyClothes[bodyIndex]);
            this.RegisterSprite(LegClothes[legIndex]);
        }


        private void EditorButtons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "BackBody":
                    this.UnRegisterSprite(BodyClothes[bodyIndex]);
                    bodyIndex = bodyIndex < 1 ? BodyClothes.Length - 1 : bodyIndex - 1;
                    this.RegisterSprite(BodyClothes[bodyIndex]);
                    break;
                case "NextBody":
                    this.UnRegisterSprite(BodyClothes[bodyIndex]);
                    bodyIndex = bodyIndex > BodyClothes.Length - 2 ? 0 : bodyIndex + 1;
                    this.RegisterSprite(BodyClothes[bodyIndex]);
                    break;
                case "BackLeg":
                    this.UnRegisterSprite(LegClothes[legIndex]);
                    legIndex = legIndex < 1 ? LegClothes.Length - 1 : legIndex - 1;
                    this.RegisterSprite(LegClothes[legIndex]);
                    break;
                case "NextLeg":
                    this.UnRegisterSprite(LegClothes[legIndex]);
                    legIndex = legIndex > LegClothes.Length - 2 ? 0 : legIndex + 1;
                    this.RegisterSprite(LegClothes[legIndex]);
                    break;
                case "ChangeSex":
                    if (User.sex == "woman")
                    {
                        editorCharacter.Sprite = Resource.ManCharacter;
                        User.sex = "man";
                    }
                    else
                    {
                        editorCharacter.Sprite = Resource.WomanCharacter;
                        User.sex = "woman";
                    }
                    break;

            }
        }
        private void EditorBackButton_Click(object sender, EventArgs e)
        {
            Engine.Engine.GetScene("menu");
        }
    }
}
