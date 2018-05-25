
CREATE TRIGGER `tr_on_transactions_expenses_delete` BEFORE DELETE ON `transactions` FOR EACH ROW BEGIN
    DECLARE expense_id INT;
    SET expense_id = (SELECT te.expense_id FROM transactions_expenses AS te WHERE te.transaction_id = OLD.id LIMIT 1);
	DELETE FROM expenses WHERE id = expense_id;
END ;

CREATE TRIGGER `tr_on_transactions_revenues_delete` BEFORE DELETE ON `transactions` FOR EACH ROW BEGIN
	DECLARE rev_id INT;
    SET rev_id = (SELECT tr.revenue_id FROM transactions_revenues AS tr WHERE tr.transaction_id = OLD.id LIMIT 1);
    DELETE FROM revenues WHERE id = rev_id;
END ;