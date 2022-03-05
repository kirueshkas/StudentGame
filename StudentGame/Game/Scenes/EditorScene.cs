﻿using System;
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
       
        Button backBodyButton = Interface.CreateButton(250, 50, 200, 400, "BackBody", "backBody");
        Button nextBudyButton = Interface.CreateButton(250, 50, 1500, 400, "NextBody", "nextBody");
        Button backLegButton = Interface.CreateButton(250, 50, 200, 600, "BackLeg", "backLeg");
        Button nextLegButton = Interface.CreateButton(250, 50, 1500, 600, "NextLeg", "nextLeg");
        Button changeSexButton = Interface.CreateButton(250, 50, 830, 10, "ChangeSex", "ChangeSex");
        Sprite2D editorCharacter = new Sprite2D(new Point(870, 550), "Character", Resource.ManCharacter);

        Label sexLabel = Interface.CreateLabel(245, 100, 55 , 150, "Sex");
        Label skinLabel = Interface.CreateLabel(245, 100, 305, 150, "Skin");
        Label hairLabel = Interface.CreateLabel(245, 100, 175, 290, "Hair");

        Button backHairButton = Interface.CreateButton(50, 35, 75, 230, "BackHair", "backHair", Resource.arror, false);
        Button nextHairButton = Interface.CreateButton(50, 35, 230, 230, "NextHair", "nextHair", Resource.arror, false);

        Label hatLabel = Interface.CreateLabel(245, 100, 55, 430, "Hat");
        Label upperLabel = Interface.CreateLabel(245, 100, 305, 430, "Upper");
        Label bottomLabel = Interface.CreateLabel(245, 100, 175, 570, "Bottom");
        Label shoesLabel = Interface.CreateLabel(245, 100, 55, 710, "Shoes");

        public override void OnLoad()
        {
            CreateEdtior();
        }

        public override void OnUpdate()
        {
        }


        public void CreateEdtior()
        {
            this.RegisterLabel(sexLabel);
            this.RegisterLabel(skinLabel);
            RegisterLabel(hairLabel);
            RegisterLabel(hatLabel);
            RegisterLabel(upperLabel);
            RegisterLabel(bottomLabel);
            RegisterLabel(shoesLabel);
            this.RegisterButton(backButton);
            backButton.Click += EditorBackButton_Click;
            this.RegisterSprite(secondHand);
            this.RegisterButton(backHairButton);
            this.RegisterButton(nextHairButton);
            nextHairButton.Click += EditorButtons_Click;
            this.RegisterButton(backBodyButton);
            backHairButton.Click += EditorButtons_Click;
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
            this.RegisterSprite(Clothes.ManHair[Clothes.hairIndex]);
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
                case "NextHair":
                    if (User.sex == "woman")
                    {
                        this.UnRegisterSprite(Clothes.WomanHair[Clothes.hairIndex]);
                        Clothes.hairIndex = Clothes.hairIndex > Clothes.WomanHair.Length - 2 ? 0 : Clothes.hairIndex + 1;
                        this.RegisterSprite(Clothes.WomanHair[Clothes.hairIndex]);
                    }
                    else
                    {
                        this.UnRegisterSprite(Clothes.ManHair[Clothes.hairIndex]);
                        Clothes.hairIndex = Clothes.hairIndex > Clothes.ManHair.Length - 2 ? 0 : Clothes.hairIndex + 1;
                        this.RegisterSprite(Clothes.ManHair[Clothes.hairIndex]);
                    }    
                    break;
                case "BackHair":
                    if (User.sex == "woman")
                    {
                        this.UnRegisterSprite(Clothes.WomanHair[Clothes.hairIndex]);
                        Clothes.hairIndex = Clothes.hairIndex < 1 ? Clothes.WomanHair.Length - 1 : Clothes.hairIndex - 1;
                        this.RegisterSprite(Clothes.WomanHair[Clothes.hairIndex]);
                    }
                    else
                    {
                        this.UnRegisterSprite(Clothes.ManHair[Clothes.hairIndex]);
                        Clothes.hairIndex = Clothes.hairIndex < 1 ? Clothes.WomanHair.Length - 1 : Clothes.hairIndex - 1;
                        this.RegisterSprite(Clothes.ManHair[Clothes.hairIndex]);
                    }
                    break;
                case "ChangeSex":
                    if (User.sex == "woman")
                    {
                        editorCharacter.Sprite = Resource.ManCharacter;
                        this.UnRegisterSprite(Clothes.WomanHair[Clothes.hairIndex]);
                        this.RegisterSprite(Clothes.ManHair[Clothes.hairIndex]);
                        User.sex = "man";
                    }
                    else
                    {
                        this.UnRegisterSprite(Clothes.ManHair[Clothes.hairIndex]);
                        this.RegisterSprite(Clothes.WomanHair[Clothes.hairIndex]);
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
