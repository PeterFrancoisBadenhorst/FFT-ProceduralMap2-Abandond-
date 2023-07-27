//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class VisualStateManager : DependencyObject {
  internal new static VisualStateManager CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new VisualStateManager(cPtr, cMemoryOwn);
  }

  internal VisualStateManager(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(VisualStateManager obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public VisualStateManager() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_VisualStateManager();
  }

  public static VisualStateManager GetCustomVisualStateManager(DependencyObject obj) {
    if (obj == null) throw new ArgumentNullException("obj");
    {
      IntPtr cPtr = NoesisGUI_PINVOKE.VisualStateManager_GetCustomVisualStateManager(DependencyObject.getCPtr(obj));
      return (VisualStateManager)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static void SetCustomVisualStateManager(DependencyObject obj, VisualStateManager value) {
    if (obj == null) throw new ArgumentNullException("obj");
    {
      NoesisGUI_PINVOKE.VisualStateManager_SetCustomVisualStateManager(DependencyObject.getCPtr(obj), VisualStateManager.getCPtr(value));
    }
  }

  public static VisualStateGroupCollection GetVisualStateGroups(DependencyObject obj) {
    if (obj == null) throw new ArgumentNullException("obj");
    {
      IntPtr cPtr = NoesisGUI_PINVOKE.VisualStateManager_GetVisualStateGroups(DependencyObject.getCPtr(obj));
      return (VisualStateGroupCollection)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static void SetVisualStateGroups(DependencyObject obj, VisualStateGroupCollection groups) {
    if (obj == null) throw new ArgumentNullException("obj");
    {
      NoesisGUI_PINVOKE.VisualStateManager_SetVisualStateGroups(DependencyObject.getCPtr(obj), VisualStateGroupCollection.getCPtr(groups));
    }
  }

  public static bool GoToState(FrameworkElement control, string stateName, bool useTransitions) {
    bool ret = NoesisGUI_PINVOKE.VisualStateManager_GoToState(FrameworkElement.getCPtr(control), stateName != null ? stateName : string.Empty, useTransitions);
    return ret;
  }

  public static bool GoToElementState(FrameworkElement root, string stateName, bool useTransitions) {
    bool ret = NoesisGUI_PINVOKE.VisualStateManager_GoToElementState(FrameworkElement.getCPtr(root), stateName != null ? stateName : string.Empty, useTransitions);
    return ret;
  }

  public static DependencyProperty CustomVisualStateManagerProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.VisualStateManager_CustomVisualStateManagerProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty VisualStateGroupsProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.VisualStateManager_VisualStateGroupsProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

}

}

