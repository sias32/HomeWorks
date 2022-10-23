﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork_05
{
    public static class HomeWork_05
    {
        public static void Main()
        {
            Quadcopter quadcopter = new Quadcopter("Salut01");

            var info = quadcopter.GetInfo();
            Console.WriteLine($"Info[ {info} ]");

            foreach (var item in quadcopter.GetComponents())
            {
                Console.WriteLine("Component: " + item);
            }

            quadcopter.Charge();


            Console.WriteLine();

            IRobot robot = new Quadcopter("Robot01");
            IFlyingRobot flyingRobot = new Quadcopter("FlyingRobot01");

            IRobot[] robots = { robot, flyingRobot };
            foreach (var item in robots)
            {
                var robotInfo = item.GetInfo();
                Console.WriteLine($"Info[ {robotInfo} ]");

                var robotType = item.GetRobotType();
                Console.WriteLine("Type: " + robotType);

                Console.WriteLine();
            }

            Console.WriteLine
            (
                "Реализация всех методов\n" +
                "Методы IRobot\n"
            );

            //Реализация всех методов IRobot через класс Robot
            IRobot bot1 = new Robot();
            Console.WriteLine("GetRobotType: " + bot1.GetRobotType());
            Console.WriteLine("GetComponents: " + bot1.GetComponents()[bot1.GetComponents().Count-1]);
            Console.WriteLine("GetInfo: " + bot1.GetInfo());
            Console.WriteLine();

            Console.WriteLine
            (
                "Реализация всех методов\n" +
                "Методы IFlyingRobot\n"
            );

            //Реализация всех методов IFlyingRobot через класс FlyingRobot
            IFlyingRobot bot2 = new FlyingRobot();
            Console.WriteLine("GetRobotType: " + bot2.GetRobotType());
            Console.WriteLine("GetComponents: " + bot2.GetComponents()[bot1.GetComponents().Count - 1]);
            Console.WriteLine("GetInfo: " + bot2.GetInfo());
            Console.WriteLine();

            Console.WriteLine
            (
                "Реализация всех методов\n" +
                "Методы IChargeable\n"
            );

            //Реализация всех методов IChargeable через класс Chargeable
            //Поскольку в интерфейсе IChargeable нет методов по умолчанию, можно указать что bot3 является классом
            Chargeable bot3 = new Chargeable();
            Console.Write("Charge: ");
            bot3.Charge();
            Console.WriteLine("GetInfo: " + bot3.GetInfo());
        }
    }

    interface IRobot
    {
        string GetInfo();
        List<string> GetComponents();
        string GetRobotType() => "I am a simple robot.";
    }

    interface IChargeable
    {
        string GetInfo();

        void Charge();
    }

    interface IFlyingRobot : IRobot
    {
        new string GetRobotType() => "I am a flying robot.";
    }

    public class Quadcopter : IFlyingRobot, IChargeable
    {
        private List<string> components = new List<string>() { "rotor1", "rotor2", "rotor3", "rotor4" };

        public void Charge()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");
        }

        public List<string> GetComponents() => components;

        public Quadcopter(string name) => _info = "Name: " + name;


        // Скрытая переменная
        private string _info;
        // Через метод можно информацию получить
        public string GetInfo() => _info;
    }

    public class Robot : IRobot
    {
        public List<string> GetComponents() => new List<string>() { "Пустой лист" };

        public string GetInfo() => "Я класс Robot, от интерфейса IRobot";

        //Переопределил метод, в классе
        string IRobot.GetRobotType() => "Я метод IRobot, переопределен в классе Robot";
    }

    public class Chargeable : IChargeable
    {
        public void Charge()
        {
            Console.WriteLine("Заряжен на 100%");
        }

        public string GetInfo() => "Я класс Chargeable, от интерфейса IChargeable";
    }

    public class FlyingRobot : IFlyingRobot
    {
        public List<string> GetComponents() => new List<string>() { "Пустой лист" };

        public string GetInfo() => "Я класс FlyingRobot, от интерфейса IFlyingRobot";
    }
}