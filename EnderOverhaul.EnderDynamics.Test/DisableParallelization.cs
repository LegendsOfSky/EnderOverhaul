using Xunit;

// Disable all test parallelization for this assembly.
// This ensures that tests run one-by-one (serially) because many tests
// rely on shared global state (EnderDynamicsConfig, loaded implementation assemblies,
// static event handlers, etc.).
[assembly: CollectionBehavior(DisableTestParallelization = true)]
