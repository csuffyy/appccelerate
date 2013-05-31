﻿//-------------------------------------------------------------------------------
// <copyright file="SenderAndEventArgsDelegateWrapper.cs" company="Appccelerate">
//   Copyright (c) 2008-2013
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.EventBroker.Internals.Subscriptions
{
    using System;
    using System.Reflection;

    public class SenderAndEventArgsDelegateWrapper : DelegateWrapper
    {
        public SenderAndEventArgsDelegateWrapper(Type eventArgsType, MethodInfo handlerMethod)
            : base(
                eventArgsType,
                typeof(EventHandler<>).MakeGenericType(eventArgsType), 
                handlerMethod)
        {
        }

        public override void Invoke(object subscriber, object sender, EventArgs e)
        {
            Delegate d = this.CreateSubscriptionDelegate(subscriber);

            d.DynamicInvoke(sender, e);
        }
    }
}