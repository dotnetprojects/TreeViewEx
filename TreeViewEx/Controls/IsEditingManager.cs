using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace System.Windows.Controls
{
    class IsEditingManager:InputSubscriberBase
    {
        TreeViewEx treeview;
        TreeViewExItem editedItem;

        public IsEditingManager(TreeViewEx treeview)
        {
            this.treeview = treeview;
        }

        internal override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            StopEditing(true);
        }

        public void StartEditing(TreeViewExItem item)
        {
            StopEditing(false);
            editedItem = item;
            editedItem.IsEditingCallbackEnabled = false;
            editedItem.IsEditing = true;
            editedItem.IsEditingCallbackEnabled = true;
        }

        internal void StopEditing(bool raiseEvent)
        {
            if (editedItem == null) return;

            Keyboard.Focus(editedItem);
            editedItem.IsEditingCallbackEnabled = false;
            editedItem.IsEditing = false;
            editedItem.IsEditingCallbackEnabled = true;
            FocusHelper.Focus(editedItem);
            if(raiseEvent)
                editedItem.RaiseOnEdited();
            editedItem = null;
        }
    }
}