# Diablo In Unity

A clone of Diablo 2 created in Unity following the series by [Sebastian Graves](https://www.youtube.com/@SebatianGraves).

The playlist can be found [here](https://www.youtube.com/watch?v=Jnrs1FCJ6_s&list=PLXjMXZTuWaqI).

## Episode 1

- Use namespaces for your own code.
- Coroutines can use a while loop as long as each loop `yield return null;`
  ```c#
  IEnumerator LoopSample()
  {
      // 'i' is tracked by the coroutine.
      int i = 0;
      while (i < 10)
      {
          i++;
          yield return null; // waits for the next frame.
      }
  }
  ```
- Added a call to disable the `PRESS START` button.
- Clamped the alpha to `0` or `1` after fading.
