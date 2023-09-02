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

public class Storyboard : ParallelTimeline {
  internal new static Storyboard CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new Storyboard(cPtr, cMemoryOwn);
  }

  internal Storyboard(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Storyboard obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public Storyboard() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_Storyboard();
  }

  public static string GetTargetName(DependencyObject element) {
    if (element == null) throw new ArgumentNullException("element");
    {
      IntPtr strPtr = NoesisGUI_PINVOKE.Storyboard_GetTargetName(DependencyObject.getCPtr(element));
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public static void SetTargetName(DependencyObject element, string name) {
    if (element == null) throw new ArgumentNullException("element");
    {
      NoesisGUI_PINVOKE.Storyboard_SetTargetName(DependencyObject.getCPtr(element), name != null ? name : string.Empty);
    }
  }

  public static PropertyPath GetTargetProperty(DependencyObject element) {
    if (element == null) throw new ArgumentNullException("element");
    {
      IntPtr cPtr = NoesisGUI_PINVOKE.Storyboard_GetTargetProperty(DependencyObject.getCPtr(element));
      return (PropertyPath)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static void SetTargetProperty(DependencyObject element, PropertyPath path) {
    if (element == null) throw new ArgumentNullException("element");
    {
      NoesisGUI_PINVOKE.Storyboard_SetTargetProperty(DependencyObject.getCPtr(element), PropertyPath.getCPtr(path));
    }
  }

  public static DependencyObject GetTarget(DependencyObject element) {
    if (element == null) throw new ArgumentNullException("element");
    {
      IntPtr cPtr = NoesisGUI_PINVOKE.Storyboard_GetTarget(DependencyObject.getCPtr(element));
      return (DependencyObject)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static void SetTarget(DependencyObject element, DependencyObject target) {
    if (element == null) throw new ArgumentNullException("element");
    {
      NoesisGUI_PINVOKE.Storyboard_SetTarget(DependencyObject.getCPtr(element), DependencyObject.getCPtr(target));
    }
  }

  public void Begin() {
    NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_0(swigCPtr);
  }

  public void Begin(FrameworkElement target) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_1(swigCPtr, FrameworkElement.getCPtr(target));
    }
  }

  public void Begin(FrameworkElement target, bool isControllable) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_2(swigCPtr, FrameworkElement.getCPtr(target), isControllable);
    }
  }

  public void Begin(FrameworkElement target, HandoffBehavior handoffBehavior) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_3(swigCPtr, FrameworkElement.getCPtr(target), (int)handoffBehavior);
    }
  }

  public void Begin(FrameworkElement target, HandoffBehavior handoffBehavior, bool isControllable) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_4(swigCPtr, FrameworkElement.getCPtr(target), (int)handoffBehavior, isControllable);
    }
  }

  public void Begin(FrameworkElement target, FrameworkElement nameScope) {
    if (target == null) throw new ArgumentNullException("target");
    if (nameScope == null) throw new ArgumentNullException("nameScope");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_5(swigCPtr, FrameworkElement.getCPtr(target), FrameworkElement.getCPtr(nameScope));
    }
  }

  public void Begin(FrameworkElement target, FrameworkElement nameScope, bool isControllable) {
    if (target == null) throw new ArgumentNullException("target");
    if (nameScope == null) throw new ArgumentNullException("nameScope");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_6(swigCPtr, FrameworkElement.getCPtr(target), FrameworkElement.getCPtr(nameScope), isControllable);
    }
  }

  public void Begin(FrameworkElement target, FrameworkElement nameScope, HandoffBehavior handoffBehavior) {
    if (target == null) throw new ArgumentNullException("target");
    if (nameScope == null) throw new ArgumentNullException("nameScope");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_7(swigCPtr, FrameworkElement.getCPtr(target), FrameworkElement.getCPtr(nameScope), (int)handoffBehavior);
    }
  }

  public void Begin(FrameworkElement target, FrameworkElement nameScope, HandoffBehavior handoffBehavior, bool isControllable) {
    if (target == null) throw new ArgumentNullException("target");
    if (nameScope == null) throw new ArgumentNullException("nameScope");
    {
      NoesisGUI_PINVOKE.Storyboard_Begin__SWIG_8(swigCPtr, FrameworkElement.getCPtr(target), FrameworkElement.getCPtr(nameScope), (int)handoffBehavior, isControllable);
    }
  }

  public void Seek(TimeSpan offset) {
    TimeSpanStruct tempoffset = offset;
    {
      NoesisGUI_PINVOKE.Storyboard_Seek__SWIG_0(swigCPtr, ref tempoffset);
    }
  }

  public void Seek(TimeSpan offset, TimeSeekOrigin origin) {
    TimeSpanStruct tempoffset = offset;
    {
      NoesisGUI_PINVOKE.Storyboard_Seek__SWIG_1(swigCPtr, ref tempoffset, (int)origin);
    }
  }

  public void Seek(FrameworkElement target, TimeSpan offset, TimeSeekOrigin origin) {
    if (target == null) throw new ArgumentNullException("target");
    TimeSpanStruct tempoffset = offset;
    {
      NoesisGUI_PINVOKE.Storyboard_Seek__SWIG_2(swigCPtr, FrameworkElement.getCPtr(target), ref tempoffset, (int)origin);
    }
  }

  public void Pause() {
    NoesisGUI_PINVOKE.Storyboard_Pause__SWIG_0(swigCPtr);
  }

  public void Pause(FrameworkElement target) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Pause__SWIG_1(swigCPtr, FrameworkElement.getCPtr(target));
    }
  }

  public void Resume() {
    NoesisGUI_PINVOKE.Storyboard_Resume__SWIG_0(swigCPtr);
  }

  public void Resume(FrameworkElement target) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Resume__SWIG_1(swigCPtr, FrameworkElement.getCPtr(target));
    }
  }

  public void Stop() {
    NoesisGUI_PINVOKE.Storyboard_Stop__SWIG_0(swigCPtr);
  }

  public void Stop(FrameworkElement target) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Stop__SWIG_1(swigCPtr, FrameworkElement.getCPtr(target));
    }
  }

  public void Remove() {
    NoesisGUI_PINVOKE.Storyboard_Remove__SWIG_0(swigCPtr);
  }

  public void Remove(FrameworkElement target) {
    if (target == null) throw new ArgumentNullException("target");
    {
      NoesisGUI_PINVOKE.Storyboard_Remove__SWIG_1(swigCPtr, FrameworkElement.getCPtr(target));
    }
  }

  public bool IsPlaying() {
    bool ret = NoesisGUI_PINVOKE.Storyboard_IsPlaying__SWIG_0(swigCPtr);
    return ret;
  }

  public bool IsPlaying(FrameworkElement target) {
    if (target == null) throw new ArgumentNullException("target");
    {
      bool ret = NoesisGUI_PINVOKE.Storyboard_IsPlaying__SWIG_1(swigCPtr, FrameworkElement.getCPtr(target));
      return ret;
    }
  }

  public bool IsPaused() {
    bool ret = NoesisGUI_PINVOKE.Storyboard_IsPaused__SWIG_0(swigCPtr);
    return ret;
  }

  public bool IsPaused(FrameworkElement target) {
    if (target == null) throw new ArgumentNullException("target");
    {
      bool ret = NoesisGUI_PINVOKE.Storyboard_IsPaused__SWIG_1(swigCPtr, FrameworkElement.getCPtr(target));
      return ret;
    }
  }

  public static DependencyProperty TargetNameProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Storyboard_TargetNameProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TargetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Storyboard_TargetProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TargetPropertyProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Storyboard_TargetPropertyProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

}

}
