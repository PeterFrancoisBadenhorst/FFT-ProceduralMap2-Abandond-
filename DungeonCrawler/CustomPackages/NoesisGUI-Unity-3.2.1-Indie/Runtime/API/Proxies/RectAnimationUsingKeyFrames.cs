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

public sealed class RectAnimationUsingKeyFrames : RectAnimationBase {
  internal new static RectAnimationUsingKeyFrames CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new RectAnimationUsingKeyFrames(cPtr, cMemoryOwn);
  }

  internal RectAnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(RectAnimationUsingKeyFrames obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected internal override Rect GetCurrentValueCore(Rect defaultOriginValue, Rect defaultDestinationValue, AnimationClock animationClock) {
    return GetCurrentValueCoreHelper(defaultOriginValue, defaultDestinationValue, animationClock);
  }

  public RectAnimationUsingKeyFrames() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_RectAnimationUsingKeyFrames();
  }

  public RectKeyFrameCollection KeyFrames {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.RectAnimationUsingKeyFrames_KeyFrames_get(swigCPtr);
      return (RectKeyFrameCollection)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  private Rect GetCurrentValueCoreHelper(Rect src, Rect dst, AnimationClock clock) {
    IntPtr ret = NoesisGUI_PINVOKE.RectAnimationUsingKeyFrames_GetCurrentValueCoreHelper(swigCPtr, ref src, ref dst, AnimationClock.getCPtr(clock));
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Rect>(ret);
    }
    else {
      return new Rect();
    }
  }

}

}
