using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

class MainPage : ContentPage
{
    Entry phoneNumberText;
    Button translateButton;
    Button callButton;
    public MainPage()
    {
        this.Padding = new Thickness(20, 20, 20, 20);
       
        StackLayout panel = new StackLayout
        {
            Spacing = 15
        };

        panel.Children.Add(new Label
        {
            Text = "enter a PhoneWord:",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
        });
        panel.Children.Add(phoneNumberText= new Entry
        {
            Text = "1-855-XAMARIN"
        });
        panel.Children.Add(translateButton = new Button
        {
            Text = "translate",
        });
        panel.Children.Add(callButton = new Button
        {
            Text = "Call",
            IsEnabled = false
        });
        
        translateButton.Clicked += onTranslate;
        callButton.Clicked += OnCall;
        this.Content = panel;
    }
   
    string translateNumber;
    private void onTranslate(object sender, EventArgs e)
    {
        string enteredNumber = phoneNumberText.Text;
        translateNumber = PhoneWord.PhoneWordTranslator.ToNumber(enteredNumber);
        if (!string.IsNullOrWhiteSpace(translateNumber))
        {
            callButton.IsEnabled = true;
            callButton.Text = "Call " + translateNumber;
        }
        else
        {
            callButton.IsEnabled = false;
            callButton.Text = "Call";
        }    
    }
   async void OnCall(Object sender, System.EventArgs e)
    {
        if (await this.DisplayAlert(
            "Dial this Number",
            "Would you Like to Call " + translateNumber + "?",
            "yes",
            "No"
            ))
        {
            // todo 
        }
    }

}


