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

public class Int32Animation : Int32AnimationBase {
  internal new static Int32Animation CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new Int32Animation(cPtr, cMemoryOwn);
  }

  internal Int32Animation(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Int32Animation obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected internal override int GetCurrentValueCore(int defaultOriginValue, int defaultDestinationValue, AnimationClock animationClock) {
    return GetCurrentValueCoreHelper(defaultOriginValue, defaultDestinationValue, animationClock);
  }

  public static DependencyProperty ByProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Int32Animation_ByProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty FromProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Int32Animation_FromProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ToProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Int32Animation_ToProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty EasingFunctionProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Int32Animation_EasingFunctionProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Nullable<int> From {
    set {
      NullableInt32 tempvalue = value;
      NoesisGUI_PINVOKE.Int32Animation_From_set(swigCPtr, ref tempvalue);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.Int32Animation_From_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableInt32>(ret);
      }
      else {
        return new Nullable<int>();
      }
    }

  }

  public Nullable<int> To {
    set {
      NullableInt32 tempvalue = value;
      NoesisGUI_PINVOKE.Int32Animation_To_set(swigCPtr, ref tempvalue);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.Int32Animation_To_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableInt32>(ret);
      }
      else {
        return new Nullable<int>();
      }
    }

  }

  public Nullable<int> By {
    set {
      NullableInt32 tempvalue = value;
      NoesisGUI_PINVOKE.Int32Animation_By_set(swigCPtr, ref tempvalue);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.Int32Animation_By_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableInt32>(ret);
      }
      else {
        return new Nullable<int>();
      }
    }

  }

  public EasingFunctionBase EasingFunction {
    set {
      NoesisGUI_PINVOKE.Int32Animation_EasingFunction_set(swigCPtr, EasingFunctionBase.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Int32Animation_EasingFunction_get(swigCPtr);
      return (EasingFunctionBase)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  private int GetCurrentValueCoreHelper(int src, int dst, AnimationClock clock) {
    int ret = NoesisGUI_PINVOKE.Int32Animation_GetCurrentValueCoreHelper(swigCPtr, src, dst, AnimationClock.getCPtr(clock));
    return ret;
  }

  public Int32Animation() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    if (type == typeof(Int32Animation)) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_Int32Animation();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  internal new static IntPtr Extend(string typeName) {
    return NoesisGUI_PINVOKE.Extend_Int32Animation(Marshal.StringToHGlobalAnsi(typeName));
  }
}

}

