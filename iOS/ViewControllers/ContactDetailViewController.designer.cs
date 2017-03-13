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
    [Register ("ContactDetailViewController")]
    partial class ContactDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FirstnameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LastNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PhonenumberLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FirstnameLabel != null) {
                FirstnameLabel.Dispose ();
                FirstnameLabel = null;
            }

            if (LastNameLabel != null) {
                LastNameLabel.Dispose ();
                LastNameLabel = null;
            }

            if (PhonenumberLabel != null) {
                PhonenumberLabel.Dispose ();
                PhonenumberLabel = null;
            }
        }
    }
}