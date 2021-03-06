﻿using Natasha.CSharp.Builder;
using System;
using Xunit;

namespace NatashaUT
{

    [Trait("属性构建", "")]
    public class PropertyTemplateTest
    {
        [Fact(DisplayName = "静态属性1")]
        public void Test1()
        {

            PropertyBuilder template = new PropertyBuilder();
            var result = template
                .Attribute("[Test]")
                .Access("public")
                .Modifier("static")
                .DefinedName("Name")
                .DefinedType<string>()
                .Setter("_name = 1;")
                .Getter("return 1;")
                .Script;

            Assert.Equal($"[Test]{Environment.NewLine}public static System.String Name{{{Environment.NewLine}get{{return 1;}}{Environment.NewLine}set{{_name = 1;}}{Environment.NewLine}}}", result);

        }





        [Fact(DisplayName = "静态属性2")]
        public void Test2()
        {

            var template = new PropertyBuilder();
            var result = template
                .Attribute("[Test][Test1]")
                .Access(Natasha.Reverser.Model.AccessTypes.Public)
                .Modifier(Natasha.Reverser.Model.Modifiers.Static)
                .DefinedName("Age")
                .DefinedType(typeof(int))
                .Script;

            Assert.Equal($"[Test][Test1]{Environment.NewLine}public static System.Int32 Age{{{Environment.NewLine}get;{Environment.NewLine}set;{Environment.NewLine}}}", result);


        }




        [Fact(DisplayName = "普通属性1")]
        public void Test3()
        {

            PropertyBuilder template = new PropertyBuilder();
            var result = template
                .Attribute("[Test]")
                .Access(Natasha.Reverser.Model.AccessTypes.Public)
                .DefinedName("Name")
                .DefinedType<string>()
                .Script;

            Assert.Equal($"[Test]{Environment.NewLine}public System.String Name{{{Environment.NewLine}get;{Environment.NewLine}set;{Environment.NewLine}}}", result);


        }



        [Fact(DisplayName = "普通属性2")]
        public void Test4()
        {

            PropertyBuilder template = new PropertyBuilder();
            var result = template
                .Attribute<ClassDataAttribute>()
                .Access(Natasha.Reverser.Model.AccessTypes.Public)
                .DefinedName("Name")
                .DefinedType<string>()
                .Script;

            Assert.Equal($"[Xunit.ClassDataAttribute]{Environment.NewLine}public System.String Name{{{Environment.NewLine}get;{Environment.NewLine}set;{Environment.NewLine}}}", result);


        }
    }
}
