﻿using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition("span", ContainingClass = "k-combobox", ComponentTypeName = "combo box")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[.//input[@aria-owns='{0}_listbox']]")]
    public class KendoComboBox<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByAttribute("data-role", "combobox", Visibility = Visibility.Any)]
        [TraceLog]
        private Control<TOwner> DataControl { get; set; }

        protected override T GetValue()
        {
            string valueAsString = Scope.Get(By.TagName("input").Input()).GetValue();
            return ConvertStringToValue(valueAsString);
        }

        protected override void SetValue(T value)
        {
            string valueAsString = ConvertValueToString(value);
            Scope.Get(By.TagName("input").Input()).FillInWith(valueAsString);
        }

        protected override bool GetIsReadOnly()
        {
            return DataControl.Attributes.ReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return DataControl.IsEnabled;
        }
    }
}
