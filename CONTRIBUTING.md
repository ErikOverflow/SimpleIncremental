If you would like to contribute, please fork the repository and develop your own feature in a separate branch off of the main repository.
There will be roadmapped features for the project that can be "claimed" for development by contacting Erik through discord: https://discord.gg/R2VWR78

### 1. Please do not develop features on the main scene. Duplicate the main scene and develop there instead. Rename your new scene with your feature's name.

### 2. Avoid modifying scripts outside of your feature. An inventory feature should not need to modify the enemy feature.

### 3. Avoid 2-way dependencies on all scripts. If one script HAS to see or affect another, then the other script must be agnostic to its existence.

### 4. Keep script responsibilities to a minimum. It is easier to manage 100 scripts of small snippets of logic, than 1 giant script. This also allows you to re-use and re-purpose these scripts much more easily for other projects.

***

# Please use the following template when documenting your changes.
Copy paste the template into a markdown document.

***
<pre>
##### Dependencies:

* (Method-caller) [LinkToScript](example.com)
* (Initializer) [LinkToScript](example.com)

##### Methods:

* _PublicMethods()_ - description of use-case for the method

##### Events:

* _Event_ - trigger point for event

##### Fields:

* **field** - description if needed

##### General Overview:

General idea of how the script works. Does not detail the dependencies.
</pre>

***
