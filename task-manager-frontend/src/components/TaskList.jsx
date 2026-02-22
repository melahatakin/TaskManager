function TaskList({ tasks, onStatusChange }) {
  const statusMap = {
    0: "Todo",
    1: "InProgress",
    2: "Done",
  };

  if (tasks.length === 0) {
    return <p>Henüz görev yok</p>;
  }

  return (
    <div>
      <h3>Görevler</h3>

      {tasks.map((task) => (
        <div
          key={task.id}
          style={{
            marginBottom: 15,
            border: "1px solid #ccc",
            padding: 10,
          }}
        >
          <strong>{task.title}</strong>
          <p>{task.description}</p>
          <p>Status: {statusMap[task.status]}</p>

          {task.status === 0 && (
            <button onClick={() => onStatusChange(task.id, 1)}>
              Start
            </button>
          )}

          {task.status === 1 && (
            <button onClick={() => onStatusChange(task.id, 2)}>
              Complete
            </button>
          )}
        </div>
      ))}
    </div>
  );
}

export default TaskList;
