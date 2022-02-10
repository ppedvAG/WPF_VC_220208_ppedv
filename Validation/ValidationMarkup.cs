using System;
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
    internal class ValidationMarkup : MarkupExtension
    {
        private Binding binding;

        public ValidationMarkup(Binding binding, ValidationRuleCollection validationRules)
        {
            this.binding = binding;

            foreach (var item in validationRules)
            {
                binding.ValidationRules.Add(item);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return binding.ProvideValue(serviceProvider);
        }
    }


    public class ValidationRuleCollection : Collection<ValidationRule> { }
}
