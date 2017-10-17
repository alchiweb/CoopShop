using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    public partial class NotesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "CoopShop.DataShop.NotesEditor";

        public NotesEditorAttribute()
            : base(Key)
        {
        }
    }
}
