Used when you want to augment an object with additional functionality but you don't want to rewrite or 
alter existing code(OCP), and in adition want to keep the new functionality separate(SRP)

You have two options to do so:
	- Inherit from required object if possible; some objects are sealed
	- Build a Decorator, which simply references the decorated object(s)

"Facilitates the addition of behaviors to individual objects without inheriting from them".