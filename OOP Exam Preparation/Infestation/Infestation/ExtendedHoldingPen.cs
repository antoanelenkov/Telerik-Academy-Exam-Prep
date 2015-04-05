using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation.Supplements;

namespace Infestation
{
    class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "WeaponrySkill":
                    //this.GetUnit(commandWords[2]).AddSupplement(new WeaponrySkill());
                    break;
                case "Weapon":
                    this.GetUnit(commandWords[2]).AddSupplement(new Weapon());
                    break;
                case "PowerCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new PowerCatalyst());
                    break;
                case "InfestationSpores":
                    this.GetUnit(commandWords[2]).AddSupplement(new InfestationSpores());
                    break;
                case "HealthCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new HealthCatalyst());
                    break;
                case "AggressionCatalyst":
                    this.GetUnit(commandWords[2]).AddSupplement(new AggressionCatalyst());
                    break;
                default:
                    break;
            }
        }
        //supplement SupplementType targetUnitId

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                    var dog = new Dog(commandWords[2]);
                    this.InsertUnit(dog);
                    break;
                case "Human":
                    var human = new Human(commandWords[2]);
                    this.InsertUnit(human);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    marine.AddSupplement(new WeaponrySkill());
                    this.InsertUnit(marine);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                case InteractionType.Infest:
                    Unit targetUnit2 = this.GetUnit(interaction.TargetUnit);

                    targetUnit2.DecreaseBaseHealth(new InfestationSpores().AggressionEffect);
                    break;
                default:
                    break;
            }
        }
    }
}
