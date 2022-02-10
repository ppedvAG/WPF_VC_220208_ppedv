﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Validation
{
    //Eigene MarkupExtension zur Übergabe von als Ressourcen definierte ValidationRules (vgl. MainWindow.xaml unten)
    public class ValidationMarkup : MarkupExtension
    {
        private Binding binding;

        //Konstruktor (Die Übergabeparameter sind die Werte, welche das Objekt in XAML erwartet)
        public ValidationMarkup(Binding binding, ValidationRuleCollection validationRules)
        {
            this.binding = binding;

            //Hinzufügen der übergebenen Regeln an die Bindung
            foreach (ValidationRule rule in validationRules)
            {
                binding.ValidationRules.Add(rule);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //Rückgabe der Bindung an XAML (bei Verwendung dieser MarkupExtension als Propertybelegung in XAML)
            return binding.ProvideValue(serviceProvider);
        }
    }

    //Collectionklasse zur Sammlung von ValidationRules (vgl. Window.Resources in MainWindow.xaml)
    public class ValidationRuleCollection : Collection<ValidationRule> { }
}
