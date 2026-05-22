namespace Assignment_2.Question2
{
    // Step 1 — define delegate
    delegate void ResultHandler(Student student);

    internal class ResultChecker
    {
        // Step 2 — create events
        public event ResultHandler OnPass;
        public event ResultHandler OnFail;

        // Step 3 — check marks and fire event
        public void CheckResult(Student student)
        {
            if (student.Marks >= 50)
                OnPass(student);  // fire pass event
            else
                OnFail(student);  // fire fail event
        }
    }
}