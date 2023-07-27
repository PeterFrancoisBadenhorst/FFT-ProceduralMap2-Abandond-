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

public class EasingSizeKeyFrame : SizeKeyFrame {
  internal new static EasingSizeKeyFrame CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new EasingSizeKeyFrame(cPtr, cMemoryOwn);
  }

  internal EasingSizeKeyFrame(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(EasingSizeKeyFrame obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public static DependencyProperty EasingFunctionProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.EasingSizeKeyFrame_EasingFunctionProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public EasingFunctionBase EasingFunction {
    set {
      NoesisGUI_PINVOKE.EasingSizeKeyFrame_EasingFunction_set(swigCPtr, EasingFunctionBase.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.EasingSizeKeyFrame_EasingFunction_get(swigCPtr);
      return (EasingFunctionBase)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public EasingSizeKeyFrame() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_EasingSizeKeyFrame();
  }

}

}

