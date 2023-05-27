# Gotta Have Standards
This is an oddball experiment where I’m trying wrap an arbitrary list of standardized features around any given function. The target function cannot know anything outside of itself. 

This isn’t function chaining, where FeatureA() => FeatureB() => TargetFunction(). Rather this is more like [Matryoshka doll](https://en.wikipedia.org/wiki/Matryoshka_doll), where each function fully encapsulates subsequent functions. Execution is more like FeatureA() => FeatureB() => TargetFunction() => FeatureB() => FeatureA(). 

Yea, you’re gonna need something for that headache if you dig into this code.  :P
