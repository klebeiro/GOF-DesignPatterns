Bridge prevents a 'Cartesian product' complexity explosion avoiding the entity explosion

Ex:
	- There is a base class Thread Scheduler that can be preemptive or cooperative and can run in Windows or Unix
	- You end up with a 2x2 scenario: WindowsPTS, UnixPTS, WindowsCTS, UnixCTS

Instead of it you can implement the PreemptiveThreadScheduler and CooperativeThreadScheduler in the ThreadScheduler base class
and make it depends on a IPlatformScheduler interface or abstract class that is implemented by the OS according to the needed. This
way you can use polymorphism to deal with the method execution.

"A mechanism that decouples an interface(hierarchy) from an implementation(hierarchy)"