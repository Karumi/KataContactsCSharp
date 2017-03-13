// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace KataContactsCSharp.iOS
{
    [Register ("AddContactViewController")]
    partial class AddContactViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField firstNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField lastNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField phonenumberTextField { get; set; }

        [Action ("doneButtonClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void doneButtonClicked (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (firstNameTextField != null) {
                firstNameTextField.Dispose ();
                firstNameTextField = null;
            }

            if (lastNameTextField != null) {
                lastNameTextField.Dispose ();
                lastNameTextField = null;
            }

            if (phonenumberTextField != null) {
                phonenumberTextField.Dispose ();
                phonenumberTextField = null;
            }
        }
    }
}