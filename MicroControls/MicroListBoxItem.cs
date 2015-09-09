using System;
using System.ComponentModel;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

namespace MicroControls
{

    /// <summary>
    /// <para>___</para>
    /// <para>Derived from ListBoxItem</para>
    /// </summary>
    public class MicroListBoxItem : ListBoxItem
    {

        
         ListBox parent_;
         SolidColorBrush StateNormal = new SolidColorBrush(Color.White);
         SolidColorBrush StatePressed = new SolidColorBrush(Colors.Gray);
        /// <summary>
         /// <para><paramref name="VisualParent_"/>: The listbox where the MicroListboxItem will be added</para> 
        /// </summary>
        /// <param name="VisualParent_"></param>
         public MicroListBoxItem(ListBox VisualParent_)
        {
            parent_ = VisualParent_ as ListBox;
            VerticalAlignment = VerticalAlignment.Stretch;
            Width = parent_.Width;
            Background = StateNormal;
            
        }

         

        protected override void OnTouchDown(TouchEventArgs e)
        {
            base.OnTouchDown(e);

            parent_.SelectedItem = this;
            StateNormal = (SolidColorBrush)Background;

            this.Background = StatePressed;
        }

        protected override void OnTouchUp(TouchEventArgs e)
        {
            base.OnTouchUp(e);
            this.Background = StateNormal;
        }


        protected override void OnLostFocus(FocusChangedEventArgs e)
        {
            

            base.OnLostFocus(e);
        }
    }
}
