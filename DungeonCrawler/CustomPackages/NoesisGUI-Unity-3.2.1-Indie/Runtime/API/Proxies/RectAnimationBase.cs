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

public abstract class RectAnimationBase : AnimationTimeline {
  internal RectAnimationBase(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(RectAnimationBase obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected RectAnimationBase() {
  }

  public sealed override Type TargetPropertyType {
    get {
      return typeof(Rect);
    }
  }

  public sealed override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock) {
    if (defaultOriginValue == null) {
      throw new ArgumentNullException("defaultOriginValue");
    }
    if (defaultDestinationValue == null) {
      throw new ArgumentNullException("defaultDestinationValue");
    }
    return GetCurrentValue((Rect)defaultOriginValue, (Rect)defaultDestinationValue, animationClock);
  }

  /// <summary>Gets the current value of the animation.</summary>
  public Rect GetCurrentValue(Rect defaultOriginValue, Rect defaultDestinationValue, AnimationClock animationClock) {
    if (animationClock == null) {
      throw new ArgumentNullException("animationClock");
    }
    if (animationClock.CurrentState == ClockState.Stopped) {
      return defaultDestinationValue;
    }
    return GetCurrentValueCore(defaultOriginValue, defaultDestinationValue, animationClock);
  }

  /// <summary>Calculates a value that represents the current value of the property being animated, as determined by the host animation. </summary>
  protected internal abstract Rect GetCurrentValueCore(Rect defaultOriginValue, Rect defaultDestinationValue, AnimationClock animationClock);

  internal new static IntPtr Extend(string typeName) {
    return NoesisGUI_PINVOKE.Extend_RectAnimationBase(Marshal.StringToHGlobalAnsi(typeName));
  }
}

}

