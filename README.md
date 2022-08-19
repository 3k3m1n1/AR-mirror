<div align="center">
  <img src="reflect.png" alt="Logo" width="80" height="80">

<h3 align="center">Reality Check</h3>

  <p align="center">
    CT + VXD Intern Project
		<br/ >
		Ekemini Nkanta & Gabriel Drozdov
		<br/ >
		Summer 2022
    <br /><br />
    <a style="color:#00e692;" href="https://drive.google.com/file/d/11rzHYDq2n-I5oY9KNZ0OfhjXNl3Pj4tt/view?usp=sharing"><strong>Watch our demo! »</strong></a>
    <br />
    <br />
    Final Presentation: <a style="color:#00e692;" href="https://drive.google.com/file/d/1uL0S9lyf3Zonp1x_Z7cSvjAhGdr-XbSA/view?usp=sharing">Keynote</a>
    ·
    <a style="color:#00e692;" href="https://drive.google.com/file/d/1s2fMUy5n7BOvuyNOyZzRwSsGjas6iV9I/view?usp=sharing">PDF</a>
		·
		<a style="color:#00e692;" href="https://drive.google.com/file/d/1OiPy5hmk0omiyf2_7x_qISnEHaLH1PCg/view?usp=sharing">Zoom Recording</a>
  </p>
</div>

## Introduction
For our summer intern project, we challenged ourselves to make augmented reality more accessible, engaging, & group-friendly. The result was *Reality Check*: a prototype for room-scale AR experiences that offers seamless, body-driven interaction between people and the virtual world. Visitors are immersed via a large-format "mirror" display, rather than a headset or phone screen, and can walk around the space (or reach out and "touch" virtual objects) in order to trigger music/sounds, environmental changes, immersive cutscenes, and other events.

By eliminating most technical limitations, as well as its main barrier to entry, exhibits can now use AR to its fullest potential.

## Behind the Scenes

Reality Check is powered by the [ZED 2 stereo camera](https://www.stereolabs.com/zed-2/), which uses AI to replicate human vision.

This, combined with the [Unity game engine](https://unity.com/), offers exciting capabilities:

- Body & object detection that uniquely identifies & tracks entities within 40m, without the need for markers, bodysuits, or tracking devices
- Proper occlusion between virtual & real objects
- 3D interaction using depth sensing & spatial triggers
- Dynamic scene elements, such as adaptive audio and lighting
- Support for large groups both indoors and outdoors, with no hard limits on capacity


## Goals & Objectives

- Integrate ZED 2 stereo camera with the Unity game engine
- Prototype a "mirror" display that can detect and augment 1-3 objects in 3D, as well as reveal info / animated surprises for each one
- Pull in creative experimentation with sound & light from our *Dynamic Soundscape* and *Light as Narrator* proposals
- Conjure up bigger, mind-bending concepts for a room-scale mirror (puzzles, illusions, 3D minigames to play with trackable objects...)

### Main Objectives

- [x] Run ZED tests with pre-built Unity scenes included in SDK
	- [x] Skeleton tracking
		- [x] 3D Avatar	`(rigged mannequin is included!)`
		- [x] 2D Skeleton
	- [x] Object detection     `note: bodies register as objects too! full list of detectable objects`
		- [x] 2D bounding box and mask
		- [x] 3D bounding box
	- [x] Virtual object placement
	- [x] Planetarium	`good example for mixed reality & virtual lights`
	- [x] Movie Screen	`use it as a test backdrop to see how sharp the silhouette mask is`
- [x] Map a custom avatar to the user’s body
- [x] Place virtual objects/scenery in a physical room
- [x] Create interactions between the visitor and the virtual objects using trigger volumes

### Reach Objectives

- [x] Add adaptive audio
	- [ ] ...using FMOD?
- [x] Simulate Unity lights illuminating real objects
- [x] Add dynamic light source(s): changing color, intensity, direction…
- [ ] Create a short AR cinematic that respects the geometry of the physical room using Unity Timeline
- [ ] Detect a custom object by training our own machine learning model
<br/>(a.k.a. not a person, vehicle, bag, animal, electronic, fruit/vegetable, or sports ball)
- [ ] Map a virtual object (3D model) to an artifact
<br />*\*Edit: I discovered from the tests that we can’t track a detected object’s rotation at any given time - only its position in the scene and which pixels on screen belong to it (2D mask). But! We can still try this with larger/standing objects whose real-world counterparts wouldn’t rotate during a session - like statues, columns…*
	- [ ] Display annotations/pop-ups over it

## Credits

- ["Fantasy plants Set - Hand-painted"](https://skfb.ly/6CuSE) by [Victoria](https://sketchfab.com/victoriaesch) is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).
- ["The Altar (object №1)"](https://skfb.ly/6YDCp) by [salinaforr](https://sketchfab.com/salinaforr) is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).
- ["Runestones"](https://skfb.ly/6xSVG) by [Athikar](https://sketchfab.com/Athikar) is licensed under [Creative Commons Attribution-NonCommercial](http://creativecommons.org/licenses/by-nc/4.0/).
- ["Stylized Foliage"](https://skfb.ly/6uTpL) by [soidev](https://sketchfab.com/soidev) is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).
- ["low poly Ivy"](https://skfb.ly/ovOCP) by [spicybamer](https://sketchfab.com/spicybamer) is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).
- ["Western Cowboy (Rigged)"](https://skfb.ly/o9JI9) by [human being](https://sketchfab.com/stevedaman) is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).
- ["Low Poly Western Saloon"](https://assetstore.unity.com/packages/3d/environments/low-poly-western-saloon-85578) by [Infima Games](https://assetstore.unity.com/publishers/13489) is licensed under [Standard Unity Asset Store EULA](https://unity.com/legal/as-terms).
- ["Worldskies Free Skybox Pack"](https://assetstore.unity.com/packages/2d/textures-materials/sky/worldskies-free-skybox-pack-86517) by [PULSAR BYTES](https://assetstore.unity.com/publishers/26166) is licensed under [Standard Unity Asset Store EULA](https://unity.com/legal/as-terms).
- ["Reflect"](https://www.flaticon.com/free-icon/reflect_7559224) icon is by [creative_designer](https://www.flaticon.com/authors/creative-designer) from [Flaticon](https://www.flaticon.com/).
