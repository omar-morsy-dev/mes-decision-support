#!/usr/bin/env python3
"""Small dependency-free foundation check; not an application test suite."""
from pathlib import Path
import subprocess
import sys

ROOT = Path(__file__).resolve().parents[1]
REQUIRED = [
    'README.md', '.gitignore', '.editorconfig', 'SECURITY.md',
    'docs/research/project-charter.md', 'docs/architecture/principles.md',
    '.github/workflows/foundation.yml',
]
missing = [name for name in REQUIRED if not (ROOT / name).is_file()]
if missing:
    print('Missing required files:', ', '.join(missing), file=sys.stderr)
    sys.exit(1)

# Scan tracked files only. This is a guardrail, not a complete secret scanner.
result = subprocess.run(['git', 'ls-files'], cwd=ROOT, capture_output=True, text=True)

if result.returncode != 0:
    print(
        "Failed to inspect tracked repository files:",
        result.stderr,
        file=sys.stderr,
    )
    sys.exit(result.returncode)

paths = result.stdout.splitlines()

bad = [
    p for p in paths
    if Path(p).name == '.env'
    or p.startswith(('private/', 'research/raw-data/'))
    or '/bin/' in f'/{p}'
    or '/obj/' in f'/{p}'
]

if bad:
    print(
        'Forbidden tracked paths:',
        ', '.join(bad),
        file=sys.stderr,
    )
    sys.exit(1)

print('Foundation checks passed (file presence and tracked path guard).')
