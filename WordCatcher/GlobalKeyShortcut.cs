using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WordCatcher
{
    public class GlobalKeyShortcut
    {
        private Dictionary<KeyShortcut, GlobalKeyShortcutEvent> mShortcuts;

        private static GlobalKeyShortcut mInstance;
        public static GlobalKeyShortcut Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new GlobalKeyShortcut();
                }

                return mInstance;
            }
        }

        private GlobalKeyShortcut()
        {
            mShortcuts = new Dictionary<KeyShortcut, GlobalKeyShortcutEvent>();

            GlobalHook.KeyPressed += new KeyHookHandler(GlobalHook_KeyPressed);
            GlobalHook.KeyReleased += new KeyHookHandler(GlobalHook_KeyReleased);            
        }

        public void addShortcut(KeyShortcut shortcut, GlobalKeyShortcutEvent handler)
        {
            mShortcuts[shortcut] = handler;
        }

        public void addShortcut(KeyShortcut shortcut)
        {
            addShortcut(shortcut, null);
        }

        public void addShortcut(Keys[] keys, GlobalKeyShortcutEvent handler)
        {
            addShortcut(new KeyShortcut(keys), handler);
        }

        public void addShortcut(Keys[] keys)
        {
            addShortcut(new KeyShortcut(keys));
        }

        public void init()
        {
            GlobalHook.SetHook();
        }

        public void done()
        {
            GlobalHook.ReleaseHook();
        }

        private void GlobalHook_KeyReleased(KeyHookEventArgs args)
        {
            foreach (KeyShortcut shortcut in mShortcuts.Keys)
            {
                if (shortcut.keyReleased((Keys)args.KeyCode))
                {
                    GlobalKeyShortcutEventArgs a =
                        new GlobalKeyShortcutEventArgs(shortcut, false);

                    if (mShortcuts[shortcut] != null)
                    {
                        mShortcuts[shortcut](this, a);
                    }

                    OnShortcut(a);
                }
            }
        }

        private void GlobalHook_KeyPressed(KeyHookEventArgs args)
        {
            foreach (KeyShortcut shortcut in mShortcuts.Keys)
            {
                if (shortcut.keyPressed((Keys)args.KeyCode))
                {
                    GlobalKeyShortcutEventArgs a =
                        new GlobalKeyShortcutEventArgs(shortcut, true);

                    mShortcuts[shortcut]?.Invoke(this, a);
                    OnShortcut(a);
                }
            }
        }

        public event GlobalKeyShortcutEvent Shortcut;
        public void OnShortcut(GlobalKeyShortcutEventArgs args)
        {
            Shortcut?.Invoke(this, args);
        }
    }

    public class KeyShortcut
    {
        private Dictionary<Keys, bool> mKeys;
        private object mData;

        public object Data
        {
            get { return mData; }
        }

        public KeyShortcut() 
            : this(null, null)
        {
        }

        public KeyShortcut(Keys[] keys)
            : this(keys, null)
        {
        }

        public KeyShortcut(object data)
            : this(null, data)
        {
        }

        public KeyShortcut(Keys[] keys, object data)
        {
            mKeys = new Dictionary<Keys, bool>();
            mData = data;

            if (keys != null)
            {
                foreach (Keys key in keys)
                {
                    addKey(key);
                }
            }
        }

        public void addKey(Keys key)
        {
            mKeys[key] = false;
        }

        public void removeKey(Keys key)
        {
            mKeys.Remove(key);
        }

        public bool keyPressed(Keys key)
        {
            bool ready = isReady();

            if (mKeys.ContainsKey(key))
            {
                mKeys[key] = true;
            }

            return ready = !ready && isReady();
        }

        public bool keyReleased(Keys key)
        {
            bool ready = isReady();

            if (mKeys.ContainsKey(key))
            {
                mKeys[key] = false;
            }

            return ready = ready && !isReady();
        }

        private bool isReady()
        {
            bool ready = true;

            foreach (Keys key in mKeys.Keys)
            {
                ready = ready && mKeys[key];
            }

            return ready;
        }

        public override string ToString()
        {
            string str = "";
            foreach (Keys key in mKeys.Keys)
            {
                str += key.ToString() + " ";
            }
            return str;
        }
    }

    public delegate void GlobalKeyShortcutEvent(object sender, GlobalKeyShortcutEventArgs args);

    public class GlobalKeyShortcutEventArgs : EventArgs
    {
        private KeyShortcut mShortcut;
        private bool mPressed;

        public bool Pressed
        {
            get { return mPressed; }
        }

        public KeyShortcut Shortcut
        {
            get { return mShortcut; }
        }

        public GlobalKeyShortcutEventArgs(KeyShortcut shortcut, bool pressed)
        {
            mShortcut = shortcut;
            mPressed = pressed;
        }
    }
}
