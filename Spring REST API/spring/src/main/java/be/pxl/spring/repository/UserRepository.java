package be.pxl.spring.repository;

import java.sql.Timestamp;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.User;

@Repository
public interface UserRepository extends JpaRepository<User, Integer> {
	// LazyLoading is enabled, these queries will not return a list of sessions
	// unless explicitly JOINed with FETCH
	@Transactional(readOnly = true)
	@Query("select u from User u where (u.firstName like %?1%) or (u.lastName like %?1%)")
	List<User> findByName(String name);

	@Transactional(readOnly = true)
	List<User> findByDepartment(String department);

	@Transactional(readOnly = true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where u.id = ?1")
	User findById(int id);

	@Transactional(readOnly = true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where (u.id = ?1) and (s.startTime <= ?2) and (s.endTime >= ?2) ")
	User findByDate(int id, Timestamp timeStamp);

	@Transactional(readOnly = true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where u.id = ?1 and (s.startTime >= ?2)")
	User findByGreaterStartTime(int id, Timestamp timeStamp);

	@Transactional(readOnly = true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where u.id = ?1 and (s.endTime <= ?2) ")
	User findByLesserEndTime(int id, Timestamp timeStamp);

	@Transactional(readOnly = true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where u.id = ?1 and (s.actualTime >= ?2)")
	User findByGreaterActualTime(int id, int time);

	@Transactional(readOnly = true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where u.id = ?1 and (s.actualTime <= ?2)")
	User findByLesserActualTime(int id, int time);

	@Transactional(readOnly = true)
	@Query("select u from User u LEFT JOIN FETCH u.sessions s where u.id = ?1 and (s.startTime >= ?2) and (s.endTime <= ?3)")
	User findBetween(int id, Timestamp startTime, Timestamp endTime);
	@Transactional(readOnly = true)
	@Query("select SUM(s.actualTime) from Session s where s.userId = ?1")
	int findTotalActualTime(int id);

}
