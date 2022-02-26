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

        Button backButton = Interface.CreateButton(100, 50, 10, 10, "Back", Resource.button_new, "back");
        Sprite2D secondHand = new Sprite2D(new Point(0, 0), "secondHand", Resource.character_editor);
        Button backHelmetButton = Interface.CreateButton(250, 50, 200, 200, "BackHelmet", Resource.button_new, "backHelmet");
        Button nextHelmetButton = Interface.CreateButton(250, 50, 1500, 200, "NextHelmet", Resource.button_new, "nextHelmet");
        Button backBodyButton = Interface.CreateButton(250, 50, 200, 400, "BackBody", Resource.button_new, "backBody");
        Button nextBudyButton = Interface.CreateButton(250, 50, 1500, 400, "NextBody", Resource.button_new, "nextBody");
        Button backLegButton = Interface.CreateButton(250, 50, 200, 600, "BackLeg", Resource.button_new, "backLeg");
        Button nextLegButton = Interface.CreateButton(250, 50, 1500, 600, "NextLeg", Resource.button_new, "nextLeg");
        Button changeSexButton = Interface.CreateButton(250, 50, 830, 10, "ChangeSex", Resource.button_new, "ChangeSex");
        Sprite2D editorCharacter = new Sprite2D(new Point(870, 550), "Character", Resource.ManCharacter);
        // Button BackSceneButton = Interface.CreateButton(100, 100, 10, 10, "Back", Resource.button_new, "Back");

        

        //Clothes



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
            this.RegisterSprite(Clothes.BodyClothes[Clothes.bodyIndex]);
            this.RegisterSprite(Clothes.LegClothes[Clothes.legIndex]);
           // this.RegisterSprite(hair);
        }


        private void EditorButtons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "BackBody":
                    this.UnRegisterSprite(Clothes.BodyClothes[Clothes.bodyIndex]);
                    Clothes.bodyIndex = Clothes.bodyIndex < 1 ? Clothes.BodyClothes.Length - 1 : Clothes.bodyIndex - 1;
                    this.RegisterSprite(Clothes.BodyClothes[Clothes.bodyIndex]);
                    break;
                case "NextBody":
                    this.UnRegisterSprite(Clothes.BodyClothes[Clothes.bodyIndex]);
                    Clothes.bodyIndex = Clothes.bodyIndex > Clothes.BodyClothes.Length - 2 ? 0 : Clothes.bodyIndex + 1;
                    this.RegisterSprite(Clothes.BodyClothes[Clothes.bodyIndex]);
                    break;
                case "BackLeg":
                    this.UnRegisterSprite(Clothes.LegClothes[Clothes.legIndex]);
                    Clothes.legIndex = Clothes.legIndex < 1 ? Clothes.LegClothes.Length - 1 : Clothes.legIndex - 1;
                    this.RegisterSprite(Clothes.LegClothes[Clothes.legIndex]);
                    break;
                case "NextLeg":
                    this.UnRegisterSprite(Clothes.LegClothes[Clothes.legIndex]);
                    Clothes.legIndex = Clothes.legIndex > Clothes.LegClothes.Length - 2 ? 0 : Clothes.legIndex + 1;
                    this.RegisterSprite(Clothes.LegClothes[Clothes.legIndex]);
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
