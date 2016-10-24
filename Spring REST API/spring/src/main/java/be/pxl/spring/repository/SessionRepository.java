package be.pxl.spring.repository;

import java.sql.Timestamp;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.http.RequestEntity;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.Session;

public interface SessionRepository extends JpaRepository<Session, Integer>{

	@Transactional(readOnly = true)
	List<Session> findByUserId(int userId);
	@Transactional(readOnly = true)
	@Query("select s from Session s where (s.startTime <= ?1) and (s.endTime >= ?1)")
	List<Session> findByDate(Timestamp timeStamp);
	@Query("select s from Session s where (s.startTime >= ?1)")
	List<Session> findByGreaterStartTime(Timestamp timeStamp);

	@Query("select s from Session s where (s.endTime <= ?1)")
	List<Session> findByLesserEndTime(Timestamp timeStamp);

	@Query("select s from Session s where (s.actualTime >= ?1)")
	List<Session> findByGreaterActualTime(int time);

	@Query("select s from Session s where (s.actualTime <= ?1)")
	List<Session> findByLesserActualTime(int time);
	@Query("select s from Session s where (s.startTime >= ?1) and (s.endTime <= ?2)")
	List<Session> findBetween(Timestamp startTime, Timestamp endTime);
	@Transactional(readOnly = true)
	Session findTop1ByUserIdOrderByEndTimeDesc(int userId);
	@Transactional(readOnly = true)
	Session findTop1ByUserIdOrderByStartTimeAsc(int userId);


}
