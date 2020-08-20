﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace Finaldusk.HttpLib.Provider
{
    public class SettableActionProvider : ActionProvider
    {
        private Action<HttpWebRequest> make;
        private Action<WebHeaderCollection, Stream> success;
        private Action<WebException> fail;

        private NonActionProvider nonaction = new NonActionProvider();

        public SettableActionProvider(Action<WebHeaderCollection, Stream> success, Action<WebException> fail, Action<HttpWebRequest> make = null)
        {
            this.make = make;
            this.success = success;
            this.fail = fail;

            if (success == null)
            {
                this.success = nonaction.Success;
            }

            if (fail == null)
            {
                this.fail = nonaction.Fail;
            }

            if (make == null)
            {
                this.make = nonaction.Make;
            }
        }

        public Action<WebHeaderCollection, Stream> Success
        {
            get { return success; }
        }

        public Action<WebException> Fail
        {
            get { return fail; }
        }

        public Action<HttpWebRequest> Make
        {
            get { return make; }
        }
    }
}
