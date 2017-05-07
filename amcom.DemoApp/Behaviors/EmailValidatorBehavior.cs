using System;
using System.Text.RegularExpressions;
using amcom.DemoApp.CustomRenderers;
using Xamarin.Forms;

namespace amcom.DemoApp
{
	public class EmailValidatorBehavior : Behavior<LineEntry>
	{
		const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

		static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty
			.CreateReadOnly("IsValid",
							typeof(bool),
							typeof(EmailValidatorBehavior),
							false);

		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

		public bool IsValid
		{
			get { return (bool)GetValue(IsValidProperty); }
			private set { SetValue(IsValidPropertyKey, value); }
		}

		protected override void OnAttachedTo(LineEntry bindable) => bindable.TextChanged += HandleTextChanged;

		void HandleTextChanged(object sender, TextChangedEventArgs e) => IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));

		protected override void OnDetachingFrom(LineEntry bindable) => bindable.TextChanged -= HandleTextChanged;
	}
}