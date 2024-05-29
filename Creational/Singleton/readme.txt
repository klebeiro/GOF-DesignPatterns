Its use is almost aways a design smell.

> It's used in components that only makes sense to have one in the entire system(ex: Database repository, Object factory, etc.),
consists in provide the same instance for all utilizers generally because the constructor call is expensive in order to prevent
aditional copies

*Need to take care of lazy instantiation and thread safety

"A component which is instantiated only once"