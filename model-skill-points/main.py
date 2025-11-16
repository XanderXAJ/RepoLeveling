import numpy as np
import matplotlib.pyplot as plt
from matplotlib.ticker import MaxNLocator, FuncFormatter


def skill_points_from_cumulative_haul(cumulative_haul):
    return ((-1 + np.sqrt(1 + 4 * cumulative_haul / 75.0)) / 2).astype(int)


def main():
    max = 18001
    haul_values = np.arange(0, max, 1)
    skill_points = skill_points_from_cumulative_haul(haul_values)

    plt.plot(haul_values, skill_points)
    plt.xlabel("Cumulative Haul")
    plt.ylabel("Skill Points")
    plt.title(f"Skill Points vs Cumulative Haul (0 to {max})")
    plt.grid(True)

    # Set y-axis ticks to whole numbers only
    ax = plt.gca()
    ax.yaxis.set_major_locator(MaxNLocator(integer=True))

    # Add 'K' to x-axis tick labels
    def add_k(x):
        return f"{int(x)}K"

    ax.xaxis.set_major_formatter(FuncFormatter(add_k))

    plt.show()


if __name__ == "__main__":
    main()
