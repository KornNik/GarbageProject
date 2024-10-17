using Behaviours.Items;

namespace Behaviours.States
{
    sealed class WeaponStateController : BaseStateController
    {
        private Weapon _stateObject;
        private InactiveWeaponState _inactiveState;
        private ReloadWeaponState _reloadState;
        private NeutralWeaponState _neutralState;
        private RecoveryWeaponState _recoveryState;

        public Weapon StateObject => _stateObject;
        public ReloadWeaponState ReloadState => _reloadState;
        public NeutralWeaponState NeutralState => _neutralState;
        public RecoveryWeaponState RecoveryState => _recoveryState;
        public InactiveWeaponState InactiveState => _inactiveState;

        public WeaponStateController(Weapon stateObject) : base()
        {
            _stateObject = stateObject;
            InitializeStates();
            StartState(_neutralState);
        }

        protected override void InitializeStates()
        {
            _reloadState = new ReloadWeaponState(this);
            _neutralState = new NeutralWeaponState(this);
            _recoveryState = new RecoveryWeaponState(this);
            _inactiveState = new InactiveWeaponState(this);
        }
    }
}
