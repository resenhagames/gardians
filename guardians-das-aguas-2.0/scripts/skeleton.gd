extends CharacterBody2D

enum SkeletonState {
	idle,
	walk,
	hurt
}

@onready var anim: AnimatedSprite2D = $AnimatedSprite2D
@onready var hitbox: Area2D = $Hitbox

const SPEED = 40.0

var status: SkeletonState
var direction = 1


func _ready() -> void:
	go_to_idle_state()


func _physics_process(delta: float) -> void:

	if not is_on_floor():
		velocity += get_gravity() * delta
		
	match status:
		SkeletonState.idle:
			idle_state(delta)
		SkeletonState.walk:
			walk_state(delta)
		SkeletonState.hurt:
			hurt_state(delta)

	move_and_slide()


# ---------------- STATES ----------------

func go_to_idle_state():
	status = SkeletonState.idle
	anim.play("idle")
	velocity.x = 0
	
func go_to_walk_state():
	status = SkeletonState.walk
	anim.play("walk")
	
func go_to_hurt_state():
	status = SkeletonState.hurt
	anim.play("hurt")
	hitbox.process_mode = Node.PROCESS_MODE_DISABLED
	velocity = Vector2.ZERO


# ---------------- IDLE ----------------

func idle_state(_delta):
	velocity.x = 0
	
	# vai para walk automaticamente
	go_to_walk_state()


# ---------------- WALK ----------------

func walk_state(_delta):
	velocity.x = SPEED * direction


# ---------------- HURT ----------------

func hurt_state(_delta):
	pass


func take_damage():
	go_to_hurt_state()
