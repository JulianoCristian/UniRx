﻿using System;
using System.Collections;

namespace UnityRx
{
    public class SingleAssignmentDisposable : IDisposable
    {
        IDisposable disposable;

        public bool IsDisposed { get; private set; }

        public IDisposable Disposable
        {
            get
            {
                return disposable;
            }
            set
            {
                if (IsDisposed && value != null)
                {
                    value.Dispose();
                    return;
                }

                if (disposable != null) throw new InvalidOperationException("Disposable is already set");
                if (value == null) return;

                disposable = value;
            }
        }


        public void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}