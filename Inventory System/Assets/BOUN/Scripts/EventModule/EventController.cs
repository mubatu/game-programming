using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventModule
{
    public delegate void EventCallback<T>(T data); 

    public static class EventController {

        private static Dictionary <Type, List<Delegate>> _eventDictionary = new Dictionary<Type, List<Delegate>>();
        
        public static void AddEventListener<T>(EventCallback<T> listener) {
            List<Delegate> listeners = null;
            if (_eventDictionary.TryGetValue (typeof(T), out listeners)) {
                if (!listeners.Contains(listener)) {
                    listeners.Add(listener);
                }
            } else {
                listeners = new List<Delegate>();
                listeners.Add(listener);
                _eventDictionary.Add(typeof(T), listeners);
            }
        }

        public static void RemoveEventListener<T>(EventCallback<T> listener) {
            List<Delegate> listeners = null;
            if (_eventDictionary.TryGetValue(typeof(T), out listeners)) {
                listeners.Remove(listener);
            }
        }
        
        public static void TriggerEvent<T>(T data) {
            List<Delegate> listeners = null;
            if (_eventDictionary.TryGetValue (typeof(T), out listeners)) {
                foreach (var listener in listeners.ToArray()) {
                    listener.DynamicInvoke(data);
                }
            }
        }
        
        public static void RemoveAllEvents() {
            _eventDictionary = new Dictionary<Type, List<Delegate>>();
        }
    }
    public struct OnPointSelected
    {
        public Vector3 point;
    }
        
    public struct OnPathConfirmed
    {
    }
        
    public struct OnPathFinished
    {
    }
}